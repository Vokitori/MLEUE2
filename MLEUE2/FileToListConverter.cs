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

        public static List<Entry> FileToList(string path)
        {
            List<Entry> list = new List<Entry>();

            string line;
            StreamReader file =
                new StreamReader(path);


            while ((line = file.ReadLine()) != null)
            {
                line = line.ToLower();
                string[] identifierSplit = line.Split(new char[] { '\t' }, 2);
                Entry tempEntry = new Entry();
                if (identifierSplit[0] == "spam")
                {
                    tempEntry.Classifier = SpamHamEnum.SPAM;
                }
                else if (identifierSplit[0] == "ham")
                {
                    tempEntry.Classifier = SpamHamEnum.HAM;
                }
                else
                {
                    throw new InvalidDataException();
                }

                string[] sentenceSplit = identifierSplit[1].Split(new char[] { ' ' });

                for (int i = 0; i < sentenceSplit.Count(); i++)
                {
                    tempEntry.AddWord(new Word(sentenceSplit[i]));
                }

                list.Add(tempEntry);
            }

            file.Close();


            return list;
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
