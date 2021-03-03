using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Juan Gomez");

            string input;
            
            //Console.WriteLine($"Letra {input}");
            do
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                input = Console.ReadLine();

                try
                {
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            } while (input != "q");
            //book.AddGrade(54.23);
            //book.AddGrade(74.23);
            //book.AddGrade(94.23);

            var result = book.GetStatistics();

            Console.WriteLine(Book.test1); // se llama directamente desde la clase
            Console.WriteLine($"Lowest {result.Low}");
            Console.WriteLine($"Highest {result.High}");
            Console.WriteLine($"Average {result.Average:N1}");
            Console.WriteLine($"Letter {result.Letter}");
        }
    }

}
