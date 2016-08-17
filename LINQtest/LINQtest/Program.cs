using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtest
{
    class Program
    {

        //delegate Func<string, int> selector();

        private static int selector(string s)
        {
            return Int32.Parse(s);
        }

        static void Main(string[] args)
        {
            string[] numbers = { "40", "2012", "176", "5" };



            // Преобразуем массив строк в массив типа int используя LINQ
            //int[] nums = numbers.Select(s => Int32.Parse(s)).ToArray();

            
            int[] nums = numbers.Select(selector).ToArray();

            foreach (int n in nums)
                Console.Write(n + " ");

        }
    }
}
