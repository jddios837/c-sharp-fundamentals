using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = 34.1;
            var y = 23.3;
            var result = x + y;

            // array
            var numbers = new double[3] {12.7, 3.7, 6.1}; // create an array

            List<double> grades = new List<double>() { 12.7, 3.7, 6.1 };
            grades.Add(22);

            //numbers[0] = 12.7;
            //numbers[1] = 3.7;
            //numbers[2] = 4.7;

            var r = numbers[0];
            //r = r + numbers[1];
            //r = r + numbers[2];
            //r += numbers[1];
            //r += numbers[2];

            Console.WriteLine(r);

            foreach (var item in grades)
            {
                Console.WriteLine($"The values is {item} and the total is {r}");
                r += item;
            }

            r /= grades.Count;
            Console.WriteLine($"The average grade is {r:N1}");


            Console.WriteLine("The same but using a new class"); // snipper cw

            var testclass = new TestClass();

            testclass.ComputeAverageGrade(grades);

            Console.WriteLine("Using a new class"); // snipper cw
            var book = new Book("Juan");
            book.AddGrade(22);
            book.AddGrade(45);
            book.AddGrade(66);

            //book.ComputeAverageGrade();

            book.ShowStatistics();






            if (args.Length > 0)
            {
                Console.WriteLine($"Hello World {args[0]}!");
            } else
            {
                Console.WriteLine("Hello World!");
            }
            
        }
    }

    class TestClass
    {
        double d1 = 0;

        public void show() => Console.WriteLine($"Test class value d1 {d1}");

        public void ComputeAverageGrade(List<double> grades)
        {
            double r = grades[0];

            Console.WriteLine(r);

            foreach (var item in grades)
            {
                Console.WriteLine($"The values is {item} and the total is {r}");
                r += item;
            }

            r /= grades.Count;
            Console.WriteLine($"The average grade is {r:N1}");
        }
    }
}
