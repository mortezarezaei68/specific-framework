using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TestApps
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestList> testLists=new List<TestList>
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
            List<TestList> testListsSub=new List<TestList>
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