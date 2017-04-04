using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Word
    {
        public string Literal;
        public int Count;

        public Word(string literal)
        {
            Literal = literal;
        }

        public override bool Equals(object obj)
        {
            return ((Word)obj).Literal == Literal;
        }
        
    }
}
