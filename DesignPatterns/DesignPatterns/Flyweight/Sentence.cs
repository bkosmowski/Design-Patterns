using System.Collections.Generic;

namespace DesignPatterns.Flyweight
{
    public class Sentence
    {
        private readonly List<WordToken> _wordTokens = new List<WordToken>();
        private readonly string[] _plainSentence;

        public Sentence(string plainText)
        {
            _plainSentence = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                var wordToken = new WordToken{ Index = index };
                _wordTokens.Add(wordToken);
                return wordToken;
            }
        }

        public override string ToString()
        {
            var strings = new string [_plainSentence.Length];

            for (var index = 0; index < _plainSentence.Length; index++)
            {
                var word = _plainSentence[index];
                foreach (var wordToken in _wordTokens)
                {
                    if (wordToken.Covers(index) && wordToken.Capitalize)
                    {
                        word = word.ToUpperInvariant();
                    }
                }

                strings[index] = word;
            }

            return string.Join(" ", strings);
        }

        public class WordToken
        {
            public int Index;
            public bool Capitalize;

            public bool Covers(int index)
            {
                return Index == index;
            }
        }
    }
}
