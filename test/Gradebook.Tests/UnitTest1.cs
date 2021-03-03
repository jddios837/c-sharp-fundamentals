using System;
using Xunit;
using GradeBook;

namespace Gradebook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);
    public class UnitTest1
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void Test1()
        {
            // test has three section
            // arrange section
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act section
            var result = book.GetStatistics();

            // assert section
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
