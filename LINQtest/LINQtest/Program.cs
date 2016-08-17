using System;
using System.Collections;
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
            //exampleArray();
            //exampleEmploers();
            eArrayStrings();
        }

        private static void eArrayStrings()
        {
            string[] strings = { "one", "two", "three" };

            Console.WriteLine("Before Where() is called.");
            IEnumerable<string> ieStrings = strings.Where(s => s.Length >= 3);
            Console.WriteLine("After Where() is called.");

            foreach (string s in ieStrings)
            {
                Console.WriteLine("Processing " + s);
            }
        }

        private static void exampleArray()
        {
            string[] numbers = { "40", "2012", "176", "5" };



            // Преобразуем массив строк в массив типа int используя LINQ
            //int[] nums = numbers.Select(s => Int32.Parse(s)).ToArray();


            int[] nums = numbers.Select(selector).OrderBy(s => s).ToArray();

            foreach (int n in nums)
                Console.Write(n + " ");
        }

        private static void exampleEmploers()
        {
            ArrayList al = Employee.GetEmployees();

            /*
            Contact[] contacts = al
                .Cast<Employee>()
                .Select(e => new Contact
                {
                    id = e.id,
                    Name = string.Format("{0} {1}", e.firstName, e.lastName)
                })
                .ToArray<Contact>();
            Contact.PublishContacts(contacts);
            */

            var cs = from e in al.Cast<Employee>() select new Contact() { id = e.id, Name = e.firstName + " " + e.lastName };

            Contact.PublishContacts(cs.ToArray());

            
            Console.ReadLine();
        }

        public class Employee
        {
            public int id;
            public string firstName;
            public string lastName;

            public static ArrayList GetEmployees()
            {
                ArrayList al = new ArrayList();
                // В реальном коде коллекция заполнялась бы из базы данных
                al.Add(new Employee { id = 1, firstName = "Alexandr", lastName = "Erohin" });
                al.Add(new Employee { id = 2, firstName = "Alexey", lastName = "Volkov" });
                al.Add(new Employee { id = 3, firstName = "Dmitry", lastName = "Moiseenko" });
                return (al);
            }
        }

        public class Contact
        {
            public int id;
            public string Name;

            public static void PublishContacts(Contact[] contacts)
            {
                foreach (Contact c in contacts)
                    Console.WriteLine("Contact Id: {0} Contact: {1}", c.id, c.Name);
            }
        }
    }
}
