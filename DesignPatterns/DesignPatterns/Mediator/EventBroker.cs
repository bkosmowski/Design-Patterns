using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace DesignPatterns.Mediator
{
    public class Actor
    {
        protected EventBroker Broker;

        public Actor(EventBroker broker)
        {
            Broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
              .Subscribe(
                ps =>
                {
                    if (ps.GoalsScored < 3)
                        Console.WriteLine($"Coach: well done, {ps.Name}!");
                }
              );

            broker.OfType<PlayerSentOffEvent>()
              .Subscribe(
                ps =>
                {
                    if (ps.Reason == "violence")
                        Console.WriteLine($"Coach: How could you, {ps.Name}?");
                });
        }
    }

    public class Ref : Actor
    {
        public Ref(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerEvent>()
              .Subscribe(e =>
              {
                  if (e is PlayerScoredEvent scored)
                      Console.WriteLine($"REF: player {scored.Name} has scored his {scored.GoalsScored} goal.");
                  if (e is PlayerSentOffEvent sentOff)
                      Console.WriteLine($"REF: player {sentOff.Name} sent off due to {sentOff.Reason}.");
              });
        }
    }

    public class FootballPlayer : Actor
    {
        private readonly SerialDisposable _sentOffSubscription = new SerialDisposable();
        private readonly SerialDisposable _scoredSubscription = new SerialDisposable();
        public string Name { get; set; } = "Unknown Player";
        public int GoalsScored { get; set; } = 0;

        public void Score()
        {
            GoalsScored++;
            Broker.Publish(new PlayerScoredEvent { Name = Name, GoalsScored = GoalsScored });
        }

        public void AssaultReferee()
        {
            Broker.Publish(new PlayerSentOffEvent { Name = Name, Reason = "violence" });

            _scoredSubscription.Disposable = Disposable.Empty;
            _sentOffSubscription.Disposable = Disposable.Empty;
        }

        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            _scoredSubscription.Disposable = broker.OfType<PlayerScoredEvent>()
              .Where(ps => !ps.Name.Equals(name))
              .Subscribe(ps => Console.WriteLine($"{name}: Nicely scored, {ps.Name}! It's your {ps.GoalsScored} goal!"));

            _sentOffSubscription.Disposable = broker.OfType<PlayerSentOffEvent>()
              .Where(ps => !ps.Name.Equals(name))
              .Subscribe(ps => Console.WriteLine($"{name}: See you in the lockers, {ps.Name}."));
        }
    }



    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }

    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        private readonly ISubject<PlayerEvent> _playerEventSubscription = new Subject<PlayerEvent>(); 

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return _playerEventSubscription.Subscribe(observer);
        }

        public void Publish(PlayerEvent playerEvent)
        {
            _playerEventSubscription.OnNext(playerEvent);
        }
    }
}
