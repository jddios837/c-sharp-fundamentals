using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        //private List<double> grades = new List<double>();
        private List<double> grades;
        private string name;

        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double grade)
        {
            if(grade > 0 && grade <= 100)
            {

            }

            grades.Add(grade);
        }

        public void GetLowGrade()
        {
            Console.WriteLine($"The lowest grade is {lowGrade}");
        }

        public void GetHighGrade()
        {
            Console.WriteLine($"The highest grade is {highGrade}");
        }

        public void ComputeAverageGrade()
        {
            double r = grades[0];

            Console.WriteLine(r);

            foreach (var item in grades)
            {
                //Console.WriteLine($"The values is {item} and the total is {r}");
                lowGrade = Math.Min(item, lowGrade);
                highGrade = Math.Max(item, highGrade);
                r += item;
            }

            //r /= grades.Count;
            Console.WriteLine($"The average grade is {r:N1}");
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MinValue;
            result.High = double.MaxValue;

            //double r = grades[0];

            //Console.WriteLine(r);

            foreach (var item in grades)
            {
                //Console.WriteLine($"The values is {item} and the total is {r}");
                result.Low = Math.Min(item, result.Low);
                result.High = Math.Max(item, result.High);
                result.Average += item;
            }

            result.Average /= grades.Count;
            return result;
        }

        public void ShowStatistics()
        {
            this.GetLowGrade();
            this.GetHighGrade();
            this.ComputeAverageGrade();
        }
    }
}
