using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TestApps
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "AaBb";
            object x=new X();
            object x2=new X();
            var y=new Y();
            Console.WriteLine(x2);
        }
    }

    public class X : Y
    {
        
    }

    public class Y
    {
        public string Test { get; set; }
    }
}