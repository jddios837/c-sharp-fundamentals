using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Jua Gomez");
            book.AddGrade(54.23);
            book.AddGrade(74.23);
            book.AddGrade(94.23);

            var stats = book.GetStatistics();

            Console.WriteLine($"Lowest {stats.Low}");
            Console.WriteLine($"Highest {stats.High}");
            Console.WriteLine($"Average {stats.Average:N1}");
            Console.WriteLine($"Letter {stats.Letter}");
            

            
        }
    }

}
