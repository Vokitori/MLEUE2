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

            DecisionTree tree = new DecisionTree(@"SMSSpamCollection");
            
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
