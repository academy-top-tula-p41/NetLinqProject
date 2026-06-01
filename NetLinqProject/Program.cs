using NetLinqProject;



void PrintList<T>(IEnumerable<T> list, bool toline = true)
{
    foreach (var item in list)
        if (toline)
            Console.Write($"{item} ");
        else
            Console.WriteLine(item);
    Console.WriteLine();
}