using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MLEUE2
{
    class FileToListConverter
    {

        private FileToListConverter()
        {

        }

        public static List<Entry> FileToList(string path, out List<Entry> testData)
        {
            List<Entry> list = new List<Entry>();

            string line;
            StreamReader file =
                new StreamReader(path);


            while ((line = file.ReadLine()) != null)
            {
                Entry tempEntry = SentenceToEntry(line);

                list.Add(tempEntry);
            }

            file.Close();

            int oneTenth = list.Count / 10;
            testData = new List<Entry>();
            testData.AddRange(list.GetRange(0, oneTenth));
            list.RemoveRange(0, oneTenth);

            return list;
        }

        public static Entry SentenceToEntry(string sentence)
        {
            sentence = sentence.ToLower();
            string[] identifierSplit = sentence.Split(new char[] { '\t' }, 2);
            Entry entry = new Entry();
            if (identifierSplit[0] == "spam")
            {
                entry.Classifier = SpamHamEnum.SPAM;
            }
            else if (identifierSplit[0] == "ham")
            {
                entry.Classifier = SpamHamEnum.HAM;
            }
            else
            {
                throw new InvalidDataException();
            }

            string[] sentenceSplit = identifierSplit[1].Split(new char[] { ' ' });

            for (int i = 0; i < sentenceSplit.Count(); i++)
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                sentenceSplit[i] = rgx.Replace(sentenceSplit[i], "");
                if (sentenceSplit[i].Trim().Length < 1)
                    continue;
                entry.AddWord(new Word(sentenceSplit[i]));
            }
            return entry;

        }

        private void IdentifyTags(string[] sentence)
        {
            //for (int i = 0; i < sentence.Count; i++)
            //{
            //Regex.Match(@"\.((uk)|(us)|(fr)|(com)|(org)|(net)|(int)|(de)|(at)|(science)|(webcam)|(stream)|(men)|(party)|(study)|(top)|(click)|(gdn)|(cricket))");
            //}
        }
    }
}
