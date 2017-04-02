using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Node
    {
        private Node Yes;
        private Node No;
        public Word Word;

        private SpamHamEnum? _classifier = null;
        public SpamHamEnum? Classifier
        {
            get { return _classifier; }
            private set { _classifier = value; }
        }

        public Node(List<Entry> EntryList)
        {

        }

        public SpamHamEnum ValidateSentence(Entry entry) {
            throw new NotImplementedException();
        }
    }
}
