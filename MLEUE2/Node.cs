using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Node
    {
        private Node Yes = null;
        private Node No = null;

        public string Word;

        public SpamHamEnum? Classifier { get; private set; } = null;

        public Node(List<Entry> entryList, int head, int length, List<string> usedWords)
        {
            int ham = 0;
            int spam = 0;
            Dictionary<string, WordData> wordCount = CountWords(entryList, head, length, usedWords, ref ham, ref spam);
            double entropy = CalculationHelper.Entropy(ham, spam);
            Word = GetBestWord(entropy, wordCount, ham, spam);
          //  Console.WriteLine(Word);
            if (length == 1)
            {
                Classifier = spam > ham ? SpamHamEnum.SPAM : SpamHamEnum.HAM;
                return;
            }
            List<string> newUsedWords = new List<string>(usedWords);
            newUsedWords.Add(Word);
            int newLength = wordCount[Word].ExistsPositive + wordCount[Word].ExistsNegative;
            SortByWord(entryList, head, length);
            try
            {
                if (newLength != 0)
                    Yes = new Node(entryList, head, newLength, newUsedWords);
            }
            catch (NodeException exception) { Yes = null; }

            try
            {
                if (length - newLength != 0)
                    No = new Node(entryList, head + newLength, length - newLength, newUsedWords);
            }
            catch (NodeException exception) { No = null; }
        }

        private Dictionary<string, WordData> CountWords(List<Entry> entryList, int head, int length, List<string> usedWords, ref int ham, ref int spam)
        {
            Dictionary<string, WordData> wordCount = new Dictionary<string, WordData>();
            for (int i = head; i < head + length; i++)
            {
                Entry entry = entryList[i];
                foreach (Word word in entry.Sentence)
                {
                    if (usedWords.Contains(word.Literal)) continue;
                    WordData wordData;
                    if (!wordCount.TryGetValue(word.Literal, out wordData))
                        wordCount.Add(word.Literal, new WordData());

                    if (entry.Classifier == SpamHamEnum.HAM)
                    {
                        wordCount[word.Literal].ExistsPositive += word.Count;
                        ham++;
                    }
                    else
                    {
                        wordCount[word.Literal].ExistsNegative += word.Count;
                        spam++;
                    }
                }
            }
            return wordCount;
        }


        private string GetBestWord(double entropy, Dictionary<string, WordData> wordCount, int ham, int spam)
        {
            List<string> allWords = new List<string>(wordCount.Keys);
            double highestGain = -1;
            string bestWord = "";

            foreach (string str in allWords)
            {
                WordData data = wordCount[str];
                double gain = CalculationHelper.GainUsingTotal(entropy, data.ExistsPositive, data.ExistsNegative, ham, spam);
                if (gain > highestGain)
                {
                    highestGain = gain;
                    bestWord = str;
                }
            }
            if (bestWord == "")
                throw new NodeException();
            return bestWord;
        }

        private void SortByWord(List<Entry> entryList, int head, int length)
        {
            int lastUnsortedEntry = head;
            Word w = new Word(Word);
            for (int i = head; i < head + length; i++)
            {
                Entry entry = entryList[i];
                if (!entry.Sentence.Contains(w)) continue;
                entryList[i] = entryList[lastUnsortedEntry];
                entryList[lastUnsortedEntry] = entry;
                lastUnsortedEntry++;
            }
        }

        public SpamHamEnum ValidateSentence(Entry entry)
        {
            if (Classifier != null)
                return (SpamHamEnum)Classifier;
            if (Yes == null && No == null)
                return SpamHamEnum.HAM;
            if (entry.Sentence.Contains(new Word(Word)))
            {
                if (Yes == null)
                    return No.ValidateSentence(entry);
                return Yes.ValidateSentence(entry);
            }
            else
            {
                if (No == null)
                    return Yes.ValidateSentence(entry);
                return No.ValidateSentence(entry);
            }
        }
    }

    class NodeException : Exception
    {
        public NodeException() : base() { }
        public NodeException(string message) : base(message) { }
        public NodeException(string message, Exception innerException) : base(message, innerException) { }
    }

    class WordData
    {
        public int ExistsPositive = 0;
        public int ExistsNegative = 0;
    }
}
