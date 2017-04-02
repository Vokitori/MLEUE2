using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Entry
    {
        public SpamHamEnum Classifier;
        public List<Word> Sentence = new List<Word>();

        public override string ToString()
        {
            string s = Classifier.ToString();
            foreach (var item in Sentence)
            {
                s += " " + item;
            }

            return s;
        }

        public void AddWord(Word word)
        {
            foreach (var item in Sentence)
            {
                if (item.Equals(word))
                {
                    item.Count++;
                    return;
                }
            }
            Sentence.Add(word);
        }


    }
}
