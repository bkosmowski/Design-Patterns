using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class BrokerChain
    {
        public void Demo()
        {
            var game = new Game();
            var goblin = new BetterCreature(game, "Strong Goblin", 3, 3);
            Console.WriteLine(goblin);

            using (new BetterDoubleAttackModifier(goblin, game))
            {
                Console.WriteLine(goblin);
                using (new BetterIncreaseDefenseModifier(goblin, game))
                {
                    Console.WriteLine(goblin);
                }
            }

            Console.WriteLine(goblin);
        }
    }

    public class Query
    {
        public enum Argument
        {
            Attack, Defense
        }

        public string CreatureName { get; }


        public Argument WhatToQuery { get; }

        public int Value { get; set; }

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }
    }

    public class BetterCreature
    {
        private readonly Game _game;
        private readonly int _attack;
        private readonly int _defense;

        public string Name { get; }

        public BetterCreature(Game game, string name, int attack, int defense)
        {
            _game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _attack = attack;
            _defense = defense;
        }

        public int Attack
        {
            get
            {
                var query = new Query(Name, Query.Argument.Attack, _attack);
                _game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public int Defense
        {
            get
            {
                var query = new Query(Name, Query.Argument.Defense, _defense);
                _game.PerformQuery(this, query);
                return query.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(_attack)}: {Attack}, {nameof(_defense)}: {Defense}";
        }
    }

    public abstract class BetterCreatureModifier : IDisposable
    {
        protected readonly BetterCreature Creature;
        protected readonly Game Game;

        protected BetterCreatureModifier(BetterCreature creature, Game game)
        {
            Creature = creature;
            Game = game;
            Game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query query);

        public void Dispose()
        {
            Game.Queries -= Handle;
        }
    }

    public class BetterDoubleAttackModifier : BetterCreatureModifier
    {
        public BetterDoubleAttackModifier(BetterCreature creature, Game game) : base(creature, game)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == Creature.Name &&
                query.WhatToQuery == Query.Argument.Attack)
                query.Value *= 2;
        }
    }

    public class BetterIncreaseDefenseModifier : BetterCreatureModifier
    {
        public BetterIncreaseDefenseModifier(BetterCreature creature, Game game) : base(creature, game)
        {
        }

        protected override void Handle(object sender, Query query)
        {
            if (query.CreatureName == Creature.Name &&
                query.WhatToQuery == Query.Argument.Defense)
                query.Value += 2;
        }
    }
}
