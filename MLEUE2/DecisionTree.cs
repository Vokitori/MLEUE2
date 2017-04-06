using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2 {
    class DecisionTree {
        private List<Entry> EntryList;

        private Node _head;
        public Node Tree {
            get { return _head; }
        }

        public DecisionTree(string fileName) {
            List<Entry> entryList = FileToListConverter.FileToList(fileName);
            List<string> usedWords = new List<string>();

            _head = new Node(entryList, 0, entryList.Count(), usedWords);
        }


        public SpamHamEnum ValidateSentence(string sentence) {
            Entry entry = new Entry();
            entry.
        }
    }
}
