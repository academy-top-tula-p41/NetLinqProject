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

        public static void LinqSelectExample()
        {
            var numbers = Data.IntList();
            PrintList(numbers);

            var numbersSelectOpers = from n in numbers
                                     select n;

            PrintList(numbersSelectOpers);

            var numbersSelectMethods = numbers.Select(n => n);

            PrintList(numbersSelectMethods);

            //var obj = new { Title = "War and piece", Author = "Tolstoy Leo" };
            //Console.WriteLine($"Book: Title: {obj.Title}, Author: {obj.Author}");
            //Console.WriteLine(obj.GetType());

            var employees = Data.EmployeesList();
            PrintList(employees, false);

            var employeesNamesOpers = from e in employees
                                      select new
                                      {
                                          FirstName = e.Name,
                                          EmployeeGender = e.Gender,
                                          Age = DateTime.Now.Year - e.BirthDate.Year,
                                      };
            PrintList(employeesNamesOpers, false);

            var employeesNamesMethods = employees.Select(e => new
            {
                FirstName = e.Name,
                EmployeeGender = e.Gender,
                Age = DateTime.Now.Year - e.BirthDate.Year,
            });
            PrintList(employeesNamesMethods, false);

            var personsOpers = from e in employees
                               select new Person(e.Name, DateTime.Now.Year - e.BirthDate.Year);
            PrintList(personsOpers, false);

            var personsMethods = employees.Select(e => new Person(e.Name, DateTime.Now.Year - e.BirthDate.Year));
            PrintList(personsMethods, false);
        }

        public static void LinqWhereExample()
        {
            var names = Data.StringList();
            PrintList(names);

            var namesLengthMoreThreeOpers = from n in names
                                            where n.Length > 3 && n.Length < 6
                                            select n;
            PrintList(namesLengthMoreThreeOpers);

            var namesLengthMoreThreeMethods = names.Where(n => n.Length > 3)
                                                   .Select(n => n);
            PrintList(namesLengthMoreThreeMethods);


            var employees = Data.EmployeesList();
            PrintList(employees, false);

            var employeesMaleOpers = from e in employees
                                     where e.Gender == Gender.Male
                                            && e.BirthDate.Year >= 2000
                                     select e;
            PrintList(employeesMaleOpers, false);

            var employeesMaleMethods = employees.Where(
                e => e.Gender == Gender.Male
                     && e.BirthDate.Year >= 2000);
            PrintList(employeesMaleMethods, false);
        }

        public static void LinqOrderByExample()
        {
            var numbers = Data.IntList();
            var names = Data.StringList();
            var employees = Data.EmployeesList();

            PrintList(numbers);
            var numbersOrdersOpers = from n in numbers
                                     orderby n
                                     select n;
            PrintList(numbersOrdersOpers);

            var numbersOrdersDescOpers = from n in numbers
                                         orderby n descending
                                         select n;
            PrintList(numbersOrdersDescOpers);


            var numbersOrdersMethod = numbers.OrderBy(n => n);
            PrintList(numbersOrdersMethod);

            var numbersOrdersDescMethod = numbers.OrderByDescending(n => n);
            PrintList(numbersOrdersDescMethod);


            PrintList(names);
            var namesOrdersAlphaOpers = from n in names
                                        orderby n
                                        select n;
            PrintList(namesOrdersAlphaOpers);
            var namesOrdersAlphaDescOpers = from n in names
                                            orderby n descending
                                            select n;
            PrintList(namesOrdersAlphaDescOpers);

            var namesOrdersAlphaMethods = names.OrderBy(n => n);
            PrintList(namesOrdersAlphaMethods);
            var namesOrdersAlphaDescMethods = names.OrderByDescending(n => n);
            PrintList(namesOrdersAlphaDescMethods);


            var namesOrderLengthOpers = from n in names
                                        orderby n.Length, n descending
                                        select n;
            PrintList(namesOrderLengthOpers);

            var namesOrderLengthMethods = names.OrderBy(n => n.Length)
                                               .ThenByDescending(n => n);
            PrintList(namesOrderLengthMethods);


            PrintList(employees, false);

            var employeesOrdersOpers = from e in employees
                                       orderby e.Gender, e.Salary descending
                                       select e;
            PrintList(employeesOrdersOpers, false);

            var employeesOrdersMethods = employees.OrderBy(e => e.Gender)
                                                  .ThenByDescending(e => e.BirthDate);
            PrintList(employeesOrdersMethods, false);
        }

        public static void LinqSetsExample()
        {
            var setA = Data.IntList();
            var setB = Data.IntList();

            PrintList(setA);
            PrintList(setA.Distinct());
            PrintList(setB);
            PrintList(setB.Distinct());

            var setUnion = setA.Union(setB);
            PrintList(setUnion);

            var setIntersect = setA.Intersect(setB);
            PrintList(setIntersect);

            var setExceptA = setA.Except(setB);
            PrintList(setExceptA);

            var setExceptB = setB.Except(setA);
            PrintList(setExceptB);


            var employeesOne = Data.EmployeesList();
            var employeesTwo = Data.EmployeesList();
        }

        public static void LinqAgregatesExample()
        {
            var numbers = Data.IntList();
            PrintList(numbers);

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Where(n => n >= 50).Count());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Aggregate(1, (long a, int b) => a * b));
            Console.WriteLine();



            var employees = Data.EmployeesList();
            PrintList(employees, false);
            Console.WriteLine(employees.Count());
            Console.WriteLine(employees.Where(e => e.Gender == Gender.Male)
                                       .Count());
            Console.WriteLine(employees.Sum(e => e.Salary));
            Console.WriteLine(employees.Sum(e => DateTime.Now.Year - e.BirthDate.Year));
            Console.WriteLine(employees.Min(e => e.Salary));
            Console.WriteLine(employees.Max(e => e.BirthDate));
            Console.WriteLine(employees.Max(e => DateTime.Now.Year - e.BirthDate.Year));
            Console.WriteLine(employees.Average(e => e.Salary));
            Console.WriteLine(employees.Average(e => DateTime.Now.Year - e.BirthDate.Year));

            var namesStr = employees.Aggregate("Names:", (ns, e) => $"{ns} {e.Name}");
            Console.WriteLine(namesStr);
        }

        public static void LinqSkipTakeExample()
        {
            var employees = Data.EmployeesList();
            PrintList(employees.SkipWhile(e => e.Salary < 140000), false);
            PrintPages(employees, 3);
        }

        public static void LinqGroupingExample()
        {
            var employees = Data.EmployeesList();

            var employeesGenderGroupOpers = from e in employees
                                            group e by e.Company;

            foreach (var g in employeesGenderGroupOpers)
            {
                Console.WriteLine($"{g.Key}");
                PrintList(g, false);
                Console.WriteLine();
            }

            Console.WriteLine(new String('-', 30));

            var employeesGenderGroupMethods = employees.GroupBy(e => e.Company);
            foreach (var g in employeesGenderGroupMethods)
            {
                Console.WriteLine($"{g.Key}");
                PrintList(g, false);
                Console.WriteLine();
            }

            var employeesCompanyGroupOpers = from e in employees
                                             group e by e.Company into ec
                                             select new
                                             {
                                                 Company = ec.Key,
                                                 Count = ec.Count(),
                                                 Employees = from ee in ec
                                                             orderby ee.BirthDate
                                                             select ee,
                                             };
            foreach (var g in employeesCompanyGroupOpers)
            {
                Console.WriteLine($"Company: {g.Company}: {g.Count}");
                PrintList(g.Employees, false);
                Console.WriteLine();
            }

            var employeesCompanyGroupMethods = employees.GroupBy(e => e.Company)
                                                        .Select(g => new
                                                        {
                                                            Company = g.Key,
                                                            Count = g.Count(),
                                                            Employees = g.OrderBy(eg => eg.BirthDate),
                                                        });
            //PrintList(employeesCompanyGroupMethods, false);
            foreach (var g in employeesCompanyGroupMethods)
            {
                Console.WriteLine($"Company: {g.Company}: {g.Count}");
                PrintList(g.Employees, false);
                Console.WriteLine();
            }

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

        static void PrintPages<T>(IEnumerable<T> list, int count = 3)
        {
            int pages = (int)Math.Ceiling((double)list.Count() / count);
            for (int i = 0; i < pages; i++)
            {
                Console.Clear();

                Console.WriteLine($"Page {i + 1}");
                var listPage = list.Skip(i * count).Take(count);
                PrintList(listPage, false);
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

    }

    class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, int age)
        {
            FirstName = firstName;
            Age = age;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName}, Age: {Age}";
        }
    }
}
