using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class Exercise
    {
        public class Participant
        {
            private readonly Mediator _mediator;

            public int Value { get; set; }

            public Participant(Mediator mediator)
            {
                _mediator = mediator;
                _mediator.Join(this);
            }

            public void Say(int n)
            {
                _mediator.Broadcast(this, n);
            }
        }

        public class Mediator
        {
            private readonly List<Participant> _participants = new List<Participant>();

            public void Join(Participant participant)
            {
                _participants.Add(participant);
            }

            public void Broadcast(Participant participant, int i)
            {
                foreach (var participant1 in _participants.Where(x => x != participant))
                {
                    participant1.Value = i;
                }
            }
        }
    }
}
