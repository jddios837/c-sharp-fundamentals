using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject : Object
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class Book : NamedObject
    {
        //private List<double> grades = new List<double>();
        private List<double> grades;
        private string name;
        readonly string category = "Science"; // is posible to change in on the constructos
        
        const string test = "Math"; 
        public const string test1 = "Math1"; 

        private double highGrade = double.MinValue;
        private double lowGrade = double.MaxValue;

        //public string Name { get => name; private set => name = value; }

        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public void AddGrade(double grade)
        {
            if (grade > 0 && grade <= 100)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }    
            }
            else 
            {
                //Console.WriteLine("Invalid Value");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public void AddGrade(char grade)
        {
            switch (grade)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public event GradeAddedDelegate GradeAdded;

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
            result.Low = double.MaxValue;
            result.High = double.MinValue;

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

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

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
