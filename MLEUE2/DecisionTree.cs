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

        public Node Tree { get; }

        public DecisionTree(string fileName, out List<Entry> testData)
        {
            List<Entry> entryList = FileToListConverter.FileToList(fileName, out testData);
            List<string> usedWords = new List<string>();

            Tree = new Node(entryList, 0, entryList.Count(), usedWords);
        }

        public SpamHamEnum ValidateSentence(Entry entry)
        {
            return Tree.ValidateSentence(entry);
        }

        public SpamHamEnum ValidateSentence(string sentence)
        {
           return  ValidateSentence(FileToListConverter.SentenceToEntry(sentence));
        }
    }
}
