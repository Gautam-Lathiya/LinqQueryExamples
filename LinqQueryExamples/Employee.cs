using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryExamples
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public static List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
                new Employee { Id = 2, Name = "Bob", Department = "HR", Salary = 52000 },
                new Employee { Id = 3, Name = "Charlie", Department = "HR", Salary = 51000 },
                new Employee { Id = 4, Name = "David", Department = "IT", Salary = 60000 },
                new Employee { Id = 5, Name = "Eve", Department = "IT", Salary = 62000 },
                new Employee { Id = 6, Name = "Ayush", Department = "IT", Salary = 62000 },
                new Employee { Id = 7, Name = "Grace", Department = "Finance", Salary = 70000 },
                new Employee { Id = 8, Name = "Heidi", Department = "Finance", Salary = 72000 },
                new Employee { Id = 9, Name = "Ivan", Department = "Finance", Salary = 71000 }
            };
        }

        static void Main(string[] args)
        {

            var employees = Employee.GetEmployees();

            // -------------------------------------------------------------
            // Find employee with highest salary in each department
            var res1 = employees.GroupBy(e => e.Department)
                .Select(g => g.OrderByDescending(e=>e.Salary).First());


            // -------------------------------------------------------------
            // Find longest word in a sentence
            string sentence = "The quickest brown fox jumps over the lazy dog";

            var words = sentence.Split(' ');
            var res2 = words.OrderByDescending(w => w.Length).FirstOrDefault(); ;
            Console.WriteLine(res2);


            // -------------------------------------------------------------
            // Find second highest salary in each department - do not consider duplicates
            var res3 = employees.GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    HighestSalaryEmployee = g.OrderByDescending(e => e.Salary).Select(e => e.Salary).Distinct().ElementAt(1)
                }
                );

            foreach (var item in res3)
            {
                Console.WriteLine($"Department: {item.Department}, Highest_Sal : {item.HighestSalaryEmployee}");
            }


            // -------------------------------------------------------------
            // Find employees with names starting with "Ay"
            var res4 = employees.Where(e => e.Name.StartsWith("Ay")).Select(e => e.Name);
            foreach (var item in res4)
            {
                Console.WriteLine($"Name : {item}");
            }

            // -------------------------------------------------------------
            
        }
    }
}
