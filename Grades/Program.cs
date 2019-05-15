using System;
using System.Collections.Generic;
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
            book.Name = null;
            book.Name = "Stephen's Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.9f);
            book.AddGrade(75);
            
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);

            WriteResult("Params", stats.LowestGrade, 5,6,7);  //Params - can pass an array of variable length
            Console.Read();

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
