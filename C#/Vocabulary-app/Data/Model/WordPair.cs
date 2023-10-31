using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary_app.Data.Model
{
    public class WordPair
    {
        public WordPair(string polishWord, string englishWord)
        {
            PolishWord = polishWord;
            EnglishWord = englishWord;
        }

        public string PolishWord { get; set; }
        public string EnglishWord { get; set; }
    }
}
