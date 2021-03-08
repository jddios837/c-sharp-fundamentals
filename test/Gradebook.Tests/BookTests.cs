using GradeBook;
using System;
using Xunit;

namespace Gradebook.Tests
{
    class BookTests
    {
        public void Test1()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act

            // assert
        }
    }
}
