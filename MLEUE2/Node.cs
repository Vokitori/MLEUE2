using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Node
    {
        public Node yes;
        public Node no;

        private bool? _isSpam;
        public bool? IsSpam
        {
            get { return _isSpam; }
        }

        public Node(List<Entry> EntryList)
        {

        }

        public SpamHamEnum ValidateSentence(Entry entry) {
            throw new NotImplementedException();
        }
    }
}
