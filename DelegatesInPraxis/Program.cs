using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInPraxis
{
    public delegate bool MyDelegate(Employee e);
    // Action    -> void
    // Predicate -> bool


    class Program
    {
        static void Main(string[] args)
        {
            var employees = GetData();

            //MyDelegate del = new MyDelegate(Bedinung);
            //Func<Employee, bool> del = new Func<Employee, bool>(Bedinung);
            //var del = new Func<Employee, bool>(Bedinung);
            //Func<Employee, bool> del = Bedinung;
            //var query = Abfrage(employees, del);

            //var query = Abfrage(employees, Bedinung);

            //var query = Abfrage(employees, delegate (Employee employee)
            //{
            //    return employee.Experience < 8;
            //});

            //var query = Abfrage(employees, (Employee employee) =>
            //{
            //    return employee.Experience < 8;
            //});

            //var query = Abfrage(employees, (e) =>
            //{
            //    return e.Experience < 8;
            //});

            var query = Abfrage(employees, e => e.Experience < 8);
            var linq = employees.Where(Bedinung);

            foreach (var e in query)
                Console.WriteLine($"Id: {e.Id} | {e.Name, -10} | {e.Experience,2}");

            Console.ReadKey();
        }

        private static bool Bedinung(Employee employee)
        {
            return employee.Name.StartsWith("A");
        }

        private static IEnumerable<Employee> Abfrage(
            IEnumerable<Employee> employees,
            Func<Employee, bool> predicate)
        {
            foreach (var e in employees)
                if (predicate(e))
                    yield return e;
        }

        private static IEnumerable<Employee> GetData()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "Hans", Experience = 8},
                new Employee { Id = 2, Name = "Lisa", Experience = 9},
                new Employee { Id = 3, Name = "Stanislaus", Experience = 10},
                new Employee { Id = 4, Name = "Alex", Experience = 4},
                new Employee { Id = 5, Name = "Maria", Experience = 7},
                new Employee { Id = 6, Name = "Luise", Experience = 2},
                new Employee { Id = 7, Name = "Andreas", Experience = 5},
                new Employee { Id = 8, Name = "Max", Experience = 8},
                new Employee { Id = 9, Name = "Nick", Experience = 1},
            };
        }
    }
}
