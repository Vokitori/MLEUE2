using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2 {
    class Node {
        private Node Yes;
        private Node No;

        public Word Word;

        private SpamHamEnum? _classifier = null;
        public SpamHamEnum? Classifier {
            get { return _classifier; }
            private set { _classifier = value; }
        }

        public Node(List<Entry> entryList, int head, int length, List<Word> usedWords) {
            Dictionary<string, WordData> wordCount = new Dictionary<string, WordData>();
            int ham = 0;
            int spam = 0;
            for (int i = head; i < length; i++) {
                Entry entry = entryList[i];
                if (entry.Classifier == SpamHamEnum.HAM) {
                    entry.Sentence.ForEach((w) => {

                        if (wordCount[w.Literal] == null)
                            wordCount[w.Literal] = new WordData();
                        wordCount[w.Literal].ExistsPositive += w.Count;
                    });
                    ham++;
                } else {
                    entry.Sentence.ForEach((w) => {
                        if (wordCount[w.Literal] == null)
                            wordCount[w.Literal] = new WordData();
                        wordCount[w.Literal].ExistsNegative += w.Count;
                    });
                    spam++;
                }

            }

            double entropy = CalculationHelper.Entropy(ham, spam);
            for (int i = head; i < length; i++) {

            }
        }

        public SpamHamEnum ValidateSentence(Entry entry) {
            throw new NotImplementedException();
        }
    }

    class WordData {
        public int ExistsPositive = 0;
        public int ExistsNegative = 0;
    }
}
