using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Juan Gomez");
            book.GradeAdded += OnGradeAdded;

            book.AddGrade(54.23);
            book.AddGrade(74.23);
            book.AddGrade(94.23);

            var result = book.GetStatistics();

            Console.WriteLine(Book.test1); // se llama directamente desde la clase
            Console.WriteLine($"Lowest {result.Low}");
            Console.WriteLine($"Highest {result.High}");
            Console.WriteLine($"Average {result.Average:N1}");
            Console.WriteLine($"Letter {result.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }

}
