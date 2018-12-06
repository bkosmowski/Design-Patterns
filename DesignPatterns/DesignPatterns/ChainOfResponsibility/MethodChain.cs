using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class MethodChain
    {
        public void Demo()
        {
            var goblin = new Creature("Goblin", 2, 2);
            Console.WriteLine(goblin);

            var root = new CreatureModifier(goblin);

            root.Add(new NoBonusModifier(goblin));

            Console.WriteLine("Let's double goblin's attack...");
            root.Add(new DoubleAttackModifier(goblin));

            Console.WriteLine("Let's increase goblin's defense");
            root.Add(new IncreaseDefenseModifier(goblin));

            root.Handle();
            Console.WriteLine(goblin);
        }
    }

    public class Creature
    {
        public string Name { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public Creature(string name, int attack, int defense)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class CreatureModifier
    {
        protected readonly Creature Creature;
        private CreatureModifier _creatureModifier;

        public CreatureModifier(Creature creature)
        {
            Creature = creature;
        }

        public void Add(CreatureModifier modifier)
        {
            if (_creatureModifier == null) _creatureModifier = modifier;
            else _creatureModifier._creatureModifier = modifier;
        }

        public virtual void Handle() => _creatureModifier?.Handle();
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {Creature.Name}'s attack");
            Creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {Creature.Name}'s defense");
            Creature.Defense += 3;
            base.Handle();
        }
    }

    public class NoBonusModifier : CreatureModifier
    {
        public NoBonusModifier(Creature creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine("No bonus for you, mate!");
        }
    }
}
