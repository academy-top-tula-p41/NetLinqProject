using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinqProject
{
    static class Examples
    {
        public static void LinqIntWelcome()
        {
            var numbers = Data.IntList();
            PrintList(numbers);

            List<int> numbers50 = new List<int>();
            foreach (int num in numbers)
                if (num > 50)
                    numbers50.Add(num);
            numbers50.Sort();

            PrintList(numbers50);

            //
            var numbers50Opers = from num in numbers
                                 where num > 50
                                 orderby num
                                 select num;

            PrintList(numbers50Opers.ToList());

            //
            var numbers50Methods = numbers.Where(num => num > 50)
                                          .OrderBy(num => num)
                                          .Select(num => num);
            PrintList(numbers50Methods.ToList());

            
        }

        public static void LinqStringWelcome()
        {
            var names = Data.StringList();
            PrintList(names);

            var namesOpers = from n in names
                             where n.Length > 3
                             select n;
            PrintList(namesOpers.ToList());

            var namesMethods = names.Where(n => n.Length > 3);
            PrintList(namesMethods.ToList());
        }

        public static void LinqObjectWelcome()
        {
            var employees = Data.EmployeesList();
            PrintList(employees, false);

            var femalesOpers = from e in employees
                               where e.Gender == Gender.Female
                               orderby e.Salary
                               select e;
            PrintList(femalesOpers, false);

            var femalesMethods = employees.Where(e => e.Gender == Gender.Female)
                                          .OrderBy(e => e.Salary);
            PrintList(femalesMethods, false);


            var employeesOneOpers = from e in employees
                                    orderby e.Gender, e.BirthDate
                                    select e;
            PrintList(employeesOneOpers, false);

            var employeesOneMethods = employees.OrderBy(e => e.Gender)
                                               .ThenBy(e => e.BirthDate);
            PrintList(employeesOneMethods, false);
        }

        static void PrintList<T>(IEnumerable<T> list, bool toline = true)
        {
            foreach (var item in list)
                if (toline)
                    Console.Write($"{item} ");
                else
                    Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}
