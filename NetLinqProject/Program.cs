using NetLinqProject;

var employees = Data.EmployeesList();

var employeesGenderGroupOpers = from e in employees
                                group e by e.Company;

foreach(var g in employeesGenderGroupOpers)
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
foreach(var g in employeesCompanyGroupOpers)
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

void PrintList<T>(IEnumerable <T> list, bool toline = true)
{
    foreach (var item in list)
        if (toline)
            Console.Write($"{item} ");
        else
            Console.WriteLine(item);
    Console.WriteLine();
}


