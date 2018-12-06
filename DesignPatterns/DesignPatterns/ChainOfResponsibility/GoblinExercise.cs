using System;
using System.Collections.Generic;

namespace DesignPatterns.ChainOfResponsibility
{
    public abstract class CreatureExercise
    {
        protected readonly GameExercise GameExercise;
        protected readonly int BaseAttack;
        protected readonly int BaseDefense;

        protected CreatureExercise(GameExercise gameExercise, int baseAttack, int baseDefense)
        {
            GameExercise = gameExercise ?? throw new ArgumentNullException(nameof(gameExercise));
            BaseAttack = baseAttack;
            BaseDefense = baseDefense;
        }

        public virtual int Attack { get; }
        public virtual int Defense { get; }

        public abstract void Query(object sender, QueryExercise queryExercise);
    }

    public class QueryExercise
    {
        public enum Argument
        {
            Attack, Defense
        }

        public Argument WhatToQuery { get; }

        public int Value { get; set; }

        public QueryExercise(Argument whatToQuery, int value)
        {
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public class GoblinExercise : CreatureExercise
    {
        public GoblinExercise(GameExercise gameExercise) : base(gameExercise, 1, 1)
        {
        }

        protected GoblinExercise(GameExercise gameExercise, int baseAttack, int baseDefense) : base(gameExercise, baseAttack, baseDefense)
        {
        }

        public override int Attack
        {
            get
            {
                var query = new QueryExercise(QueryExercise.Argument.Attack, 0);
                foreach (var creature in GameExercise.Creatures)
                {
                    creature.Query(this, query);
                }

                return query.Value;
            }
        }

        public override int Defense
        {
            get
            {
                var query = new QueryExercise(QueryExercise.Argument.Defense, 0);
                foreach (var creature in GameExercise.Creatures)
                {
                    creature.Query(this, query);
                }

                return query.Value;
            }
        }

        public override void Query(object sender, QueryExercise queryExercise)
        {
            if (ReferenceEquals(this, sender))
            {
                switch (queryExercise.WhatToQuery)
                {
                    case QueryExercise.Argument.Defense:
                        queryExercise.Value += BaseDefense;
                        break;
                    case QueryExercise.Argument.Attack:
                        queryExercise.Value += BaseAttack;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (queryExercise.WhatToQuery == QueryExercise.Argument.Defense)
            {
                queryExercise.Value++;
            }
        }
    }

    public class GoblinKingExercise : GoblinExercise
    {
        public GoblinKingExercise(GameExercise gameExercise) : base(gameExercise, 3, 3)
        {
        }

        public override void Query(object sender, QueryExercise queryExercise)
        {
            if (ReferenceEquals(this, sender) == false &&
                queryExercise.WhatToQuery == QueryExercise.Argument.Attack)
            {
                queryExercise.Value++;
            }
            base.Query(sender, queryExercise);
        }
    }

    public class GameExercise
    {
        public IList<CreatureExercise> Creatures = new List<CreatureExercise>();
    }
}
