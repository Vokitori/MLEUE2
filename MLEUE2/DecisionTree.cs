using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class DecisionTree
    {
        private List<Entry> EntryList;

        private Node _head;
        public Node Tree
        {
            get { return _head; }
        }

        public DecisionTree(string fileName)
        {

        }

        
        public SpamHamEnum ValidateSentence(string entry)
        {
            throw new NotImplementedException();
        }
    }
}
