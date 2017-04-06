using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLEUE2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entry> testData;
            DecisionTree tree = new DecisionTree(@"SMSSpamCollection", out testData);

            double hamham = 0;
            double hamspam = 0;
            double spamham = 0;
            double spamspam = 0;


            foreach (var entry in testData)
            {
                if (entry.Classifier == SpamHamEnum.HAM && tree.ValidateSentence(entry) == SpamHamEnum.HAM)
                    hamham++;
                if (entry.Classifier == SpamHamEnum.SPAM && tree.ValidateSentence(entry) == SpamHamEnum.HAM)
                    hamspam++;
                if (entry.Classifier == SpamHamEnum.HAM && tree.ValidateSentence(entry) == SpamHamEnum.SPAM)
                    spamham++;
                if (entry.Classifier == SpamHamEnum.SPAM && tree.ValidateSentence(entry) == SpamHamEnum.SPAM)
                    spamspam++;
            }
            Console.WriteLine("\t\tWas HAM \tWas SPAM");
            Console.WriteLine("Expected HAM \t" + hamham + "\t\t" + hamspam);
            Console.WriteLine("Expected SPAM \t" + spamham + "\t\t" + spamspam);
            Console.WriteLine();
            Console.WriteLine("Accuracy:");
            Console.WriteLine((hamham + spamspam) / testData.Count());
            Console.ReadLine();
            //try {

            //}
            //catch (FileNotFoundException)
            //{
            //    Console.WriteLine("The File was not found.");
            //    System.Environment.Exit();

            //}
            //catch (InvalidDataException)
            //{
            //    Console.WriteLine("The Data in File cannot be read.");
            //}
        }
    }
}
