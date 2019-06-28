using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            GradeBook book = new GradeBook();

            book.NameChanged += new NameChangedDelegate(OnNameChanged);  // Add methods to delegate with +=
            book.NameChanged += OnNameChanged2;  // Can also be written like this.
            //book.NameChanged = null;  NameChanged is an event.  Events can only add or subtract a subscriber.

            book.Name = null;
            book.Name = "Stephen's Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.9f);
            book.AddGrade(75);

            StreamWriter outputFile = File.CreateText("grades.txt");
            book.WriteGrades(outputFile);

            WriteResults(book);
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int) stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
            WriteResult("Params", stats.LowestGrade, 5, 6, 7); //Params - can pass an array of variable length
            Console.Read();
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }
        static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }
        static void WriteResult(string description, float result)
        {
           // Console.WriteLine("{0}: {1:F2}", description, result);
            Console.WriteLine($"{description}: {result:F2}");
        }
        static void WriteResult(string description, params float[] result)  //params - can receive an array of variable length
        {
            Console.WriteLine($"{description}: {result[2]}");
        }

    }
}
