using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagrammes
{
    public class Anagramme
    {
        public Anagramme() 
        {
            this.letter = '\0';
            this.refNb = 0;
            this.words = new List<string>();
        }

        public char letter
        {
            get;
            set;
        }

        public long refNb
        {
            get;
            private set;
        }

        public List<string> words
        {
            get;
            private set;
        }

        public void addWord(string word)
        {
            this.words.Add(word);
            this.refNb++;
        }
    }
}
