using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Juan Gomez");
            book.AddGrade(54.23);
            book.AddGrade(74.23);
            book.AddGrade(94.23);

            var result = book.GetStatistics();

            Console.WriteLine($"Lowest {result.Low}");
            Console.WriteLine($"Highest {result.High}");
            Console.WriteLine($"Average {result.Average:N1}");
            Console.WriteLine($"Letter {result.Letter}");
        }
    }

}
