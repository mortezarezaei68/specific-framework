using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace TestApps
{
    class Program
    {
        static void Main(string[] args)
        {
            var x=new X();
            var m=new X();
            var y=new Y();
            var d=new Y();
            if (y == d)
            {
                Console.WriteLine("is true");
            }


        }
    }
    

    public struct X
    {
        
    }

    public class Y
    {
        
    }
    
    
}