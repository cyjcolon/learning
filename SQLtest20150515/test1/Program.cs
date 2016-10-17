using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void F()
        {
            try
            {
                G();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in F:" + e.Message);
                e = new Exception("F");
                throw;
            }
        }

        private static void G()
        {
            throw new Exception("G");
        }

        static void Main(string[] args)
        {
            try
            {
                F(); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in main:" + e.Message);
                
            }

            Console.ReadKey();
        }
    }
}
