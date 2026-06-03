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
        public string? Company { get; set; }

        public override string ToString()
        {
            string gender = Gender == Gender.Male ? "Male" : "Femail";
            return $"Name: {Name}, " +
                $"Company: {Company}, " +
                $"BirthDate: {BirthDate.ToShortDateString()}, " +
                $"Gender: {gender}, " +
                $"Salary: {Salary}";
        }

        public override bool Equals(object? obj)
        {
            //Employee? employee = null;
            //if(obj is Employee)
            //    employee = (Employee?)obj;

            if (obj is Employee employee)
                return this.Name == employee.Name
                    && this.BirthDate == employee.BirthDate;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.BirthDate);
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
                    Salary = 120000,
                    Company = "Yandex",
                },
                new()
                {
                    Name = "Marry",
                    BirthDate = new DateTime(1998, 11, 4),
                    Gender = Gender.Female,
                    Salary = 135000,
                    Company = "Ozon",
                },
                new()
                {
                    Name = "Tommy",
                    BirthDate = new DateTime(1995, 9, 10),
                    Gender = Gender.Male,
                    Salary = 110000,
                    Company = "Yandex",
                },
                new()
                {
                    Name = "Poppy",
                    BirthDate = new DateTime(2001, 3, 30),
                    Gender = Gender.Female,
                    Salary = 125000,
                    Company = "Mail Group",
                },
                new()
                {
                    Name = "Bobby",
                    BirthDate = new DateTime(2002, 7, 15),
                    Gender = Gender.Male,
                    Salary = 120000,
                    Company = "Ozon",
                },

                new()
                {
                    Name = "Garry",
                    BirthDate = new DateTime(1988, 11, 1),
                    Gender = Gender.Male,
                    Salary = 110000,
                    Company = "Yandex",
                },
                new()
                {
                    Name = "Susan",
                    BirthDate = new DateTime(1999, 7, 14),
                    Gender = Gender.Female,
                    Salary = 138000,
                    Company = "Mail Group",
                },
                new()
                {
                    Name = "Rokky",
                    BirthDate = new DateTime(2001, 10, 20),
                    Gender = Gender.Male,
                    Salary = 110000,
                    Company = "Yandex",
                },
                new()
                {
                    Name = "Kelly",
                    BirthDate = new DateTime(2003, 4, 18),
                    Gender = Gender.Female,
                    Salary = 145000,
                    Company = "Yandex",
                },
                new()
                {
                    Name = "Henry",
                    BirthDate = new DateTime(2000, 12, 20),
                    Gender = Gender.Male,
                    Salary = 130000,
                    Company = "Ozon",
                },
            };

            return employees;
        }
    }
}
