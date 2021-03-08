using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
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

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book
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

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;

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

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var item in grades)
            {
                result.Add(item);
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
