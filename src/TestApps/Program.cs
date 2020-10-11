using System;
using System.Collections.Generic;

namespace TestApps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testLists = new List<TestList>
            {
                new TestList
                {
                    Email = "Test@Test.com",
                    Name = "morteza",
                    TimeValue = DateTime.Now
                },

                new TestList
                {
                    Email = "Test@gmail.com",
                    Name = "ali",
                    TimeValue = DateTime.Now.AddDays(1)
                },
                new TestList
                {
                    Email = "Test@yahoo.com",
                    Name = "morteza",
                    TimeValue = DateTime.Now.AddDays(2)
                }
            };
            var testListsSub = new List<TestList>
            {
                new TestList
                {
                    Email = "Test@Test.com",
                    Name = "morteza",
                    TimeValue = DateTime.Now
                }
            };
        }

        public class TestList
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime TimeValue { get; set; }
        }

        public class Checker
        {
        }
    }
}