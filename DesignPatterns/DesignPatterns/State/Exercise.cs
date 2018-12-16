namespace DesignPatterns.State
{
    public class Exercise
    {
        public class CombinationLock
        {
            public enum State
            {
                Locked,
                Failed,
                Open
            }

            private readonly int[] _combination;
            private int _index = 0;
            private State _state;

            public CombinationLock(int[] combination)
            {
                _combination = combination;
                Status = "LOCKED";
            }

            // you need to be changing this on user input
            public string Status;
            
            public void EnterDigit(int digit)
            {
                if (_index == 0)
                {
                    Status = "";
                }
                switch (_state)
                {
                    case State.Locked:
                        if (digit == _combination[_index])
                        {
                            if (_index + 1 == _combination.Length)
                            {
                                _state = State.Open;
                                goto case State.Open;
                            }

                            Status += digit.ToString();
                        }
                        else
                        {
                            _state = State.Failed;
                            goto case State.Failed;
                        }
                        _index++;
                        break;
                    case State.Failed:
                        Status = "ERROR";
                        _index = 0;
                        break;
                    case State.Open:
                        Status = "OPEN";
                        _index = 0;
                        break;
                }
            }
        }
    }
}
