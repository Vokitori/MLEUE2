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
            List<Entry> list = FileToListConverter.FileToList(@"SMSSpamCollection");
            Console.WriteLine("afterlist");
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine(list[i].ToString());
                
            }
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
