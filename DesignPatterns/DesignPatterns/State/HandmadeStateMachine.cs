using System;
using System.Collections.Generic;

namespace DesignPatterns.State
{
    public enum State
    {
        OffHook,
        Connecting,
        Connected,
        OnHold
    }

    public enum Trigger
    {
        CallDialed,
        HungUp,
        CallConnected,
        PlacedOnHold,
        TakenOffHold,
        LeftMessage
    }


    public class HandmadeStateMachine
    {
        private static readonly Dictionary<State, List<(Trigger, State)>> rules
            = new Dictionary<State, List<(Trigger, State)>>
            {
                [State.OffHook] = new List<(Trigger, State)>
                {
                    (Trigger.CallDialed, State.Connecting)
                },
                [State.Connecting] = new List<(Trigger, State)>
                {
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.CallConnected, State.Connected)
                },
                [State.Connected] = new List<(Trigger, State)>
                {
                    (Trigger.LeftMessage, State.OffHook),
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.PlacedOnHold, State.OnHold)
                },
                [State.OnHold] = new List<(Trigger, State)>
                {
                    (Trigger.TakenOffHold, State.Connected),
                    (Trigger.HungUp, State.OffHook)
                }
            };

        public void Demo()
        {
            var state = State.OffHook;
            while (true)
            {
                Console.WriteLine($"The phone is currently {state}");
                Console.WriteLine("Select a trigger:");

                // foreach to for
                for (var i = 0; i < rules[state].Count; i++)
                {
                    var (t, _) = rules[state][i];
                    Console.WriteLine($"{i}. {t}");
                }


                var input = int.Parse(Console.ReadLine());

                var (_, s) = rules[state][input];
                state = s;
            }

        }
    }
}
