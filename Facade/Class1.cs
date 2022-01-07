using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    using System;
    using System.Linq;

    public class Sentence
    {
        private WordToken[] _tokens;
        public Sentence(string plainText)
        {
            _tokens = plainText.Split(' ')
                .Select(x => new WordToken { Word = x })
                .ToArray();
        }

        public WordToken this[int index] => _tokens[index];

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _tokens.Length; i++)
            {
                sb.Append(_tokens[i].Word);
                sb.Append(' ');
            }
            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
            private string _word;
            public string Word
            {
                get
                {
                    return Capitalize ? _word.ToUpper() : _word.ToLower();
                }
                set { _word = value; }
            }
        }
    }
}
