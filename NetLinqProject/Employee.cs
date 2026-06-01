using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLinqProject
{
    enum Gender
    {
        Male,
        Female
    }
    internal class Employee
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            string gender = Gender == Gender.Male ? "Male" : "Femail";
            return $"Name: {Name}, " +
                $"BirthDate: {BirthDate.ToShortDateString()}, " +
                $"Gender: {gender}, " +
                $"Salary: {Salary}";
        }
    }

    static class Data
    {
        public static List<int> IntList()
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for(int i = 0; i < 10; i++)
                list.Add(random.Next(0, 99));
            return list;
        }

        public static List<string> StringList()
        {
            List<string> names = new()
            {
                "Bobby", "Joe", "Poppy", "Leopold", "Yan", "Sammy"
            };
            return names;
        }

        public static List<Employee> EmployeesList()
        {
            List<Employee> employees = new()
            {
                new()
                {
                    Name = "Jonny",
                    BirthDate = new DateTime(2000, 5, 21),
                    Gender = Gender.Male,
                    Salary = 120000
                },
                new()
                {
                    Name = "Marry",
                    BirthDate = new DateTime(1998, 11, 4),
                    Gender = Gender.Female,
                    Salary = 135000
                },
                new()
                {
                    Name = "Tommy",
                    BirthDate = new DateTime(1995, 9, 10),
                    Gender = Gender.Male,
                    Salary = 110000
                },
                new()
                {
                    Name = "Poppy",
                    BirthDate = new DateTime(2001, 3, 30),
                    Gender = Gender.Female,
                    Salary = 125000
                },
                new()
                {
                    Name = "Bobby",
                    BirthDate = new DateTime(2002, 7, 15),
                    Gender = Gender.Male,
                    Salary = 120000
                },
            };

            return employees;
        }
    }
}
