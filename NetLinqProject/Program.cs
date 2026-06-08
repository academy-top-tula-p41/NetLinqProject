using NetLinqProject;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

var books = Book.GetBooks();
PrintList(books, false);

var titleAuthorOpers = from b in books
                       where !string.IsNullOrEmpty(b.Author)
                       orderby b.Author
                       select new
                       {
                           b.Title,
                           b.Author
                       };
PrintList(titleAuthorOpers, false);

var titleAuthorMethods = books.Where(b => !string.IsNullOrEmpty(b.Author))
                              .OrderBy(b => b.Author)
                              .Select(b => new
                              {
                                  b.Title,
                                  b.Author
                              });
PrintList(titleAuthorMethods, false);



Console.WriteLine(books.Average(b => b.Price));

var pubsOpers = from b in books
                where b.Price > books.Average(b => b.Price)
                select new { b.Publisher };
PrintList(pubsOpers, false);

var pubsMethods = books.Where(b => b.Price > books.Average(b => b.Price))
                       .Select(b => new { b.Publisher });
PrintList(pubsMethods, false);


var authorGroupOpers = from b in books
                       group b by b.Author into ba
                       select new
                       {
                           Author = ba.Key,
                           Books = ba.ToList(),
                       };

foreach(var a in authorGroupOpers)
{
    Console.WriteLine(a.Author);
    foreach(var b in a.Books)
        Console.WriteLine($"\t{b}");
}
Console.WriteLine(new string('-', 60));

var authorGroupMethods = books.GroupBy(b => b.Author);
foreach (var a in authorGroupMethods)
{
    Console.WriteLine(a.Key);
    foreach (var b in a)
        Console.WriteLine($"\t{b}");
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


