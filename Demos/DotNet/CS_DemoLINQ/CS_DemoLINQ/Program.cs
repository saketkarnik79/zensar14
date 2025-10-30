using System.Xml.Linq;

namespace CS_DemoLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQToObjectsDemo1();
            //LINQToObjectsDemo2();
            //LINQToObjectsDemo3();
            //LINQToObjectsDemo4();
            //LINQToObjectsDemo5();
            //LINQToObjectsDemo6();
            //LINQToFilesDemo();
            //LINQToCSVFilesDemo();
            //LINQToFilesDemo2();
            LINQToXmlDemo();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void LINQToObjectsDemo1()
        {
            //List<int> numbers= new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numbers = Enumerable.Range(1, 100).ToList();

            // Using LINQ to filter even numbers
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              select num;
            Console.WriteLine("Query Syntax Result:");
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            // Using LINQ method syntax to filter even numbers
            var evenNumbersMethod = numbers.Where(num => num % 2 == 0);
            Console.WriteLine("Method Syntax Result:");
            foreach (var num in evenNumbersMethod)
            {
                Console.WriteLine(num);
            }
        }

        private static void LINQToObjectsDemo2()
        {
            var words = new List<string> { "apple", "banana", "cherry", "date", "fig", "grape" };
            // Using LINQ to filter words that start with 'b' or later
            var filteredWords = from word in words
                                where word.Contains('a') //string.Compare(word, "b") >= 0
                                select word;
            Console.WriteLine("Filtered Words (Query Syntax):");
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
            // Using LINQ method syntax to filter words that start with 'b' or later
            var filteredWordsMethod = words.Where(word => string.Compare(word, "b") >= 0);
            Console.WriteLine("Filtered Words (Method Syntax):");
            foreach (var word in filteredWordsMethod)
            {
                Console.WriteLine(word);
            }
        }

        private static void LINQToObjectsDemo3()
        {
            var numbers= Enumerable.Range(1, 20).ToList();
            // Get even numbers and order them descending using query syntax
            var processedNumbersQuery = from n in numbers
                                        where n % 2 == 0
                                        orderby n descending
                                        select n;
            //var processedNumbers = numbers
            //    .Where(n => n % 2 == 0)
            //    .OrderByDescending(n => n)
            //    .Select(n => n );

            Console.WriteLine("Processed Numbers (Query Syntax):");
            foreach (var num in processedNumbersQuery)
            {
                Console.WriteLine(num);
            }
        }

        private static void LINQToObjectsDemo4()
        {
            var names = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };

            // Get name lengths using query syntax
            var nameLengthsQuery = from name in names
                                   select new { Name = name, Length = name.Length};

            // Get Names & Name Lengths Displayed on Console
            foreach (var item in nameLengthsQuery)
            {
                Console.WriteLine($"Name: {item.Name}, Length: {item.Length}");
            }
        }

        private static void LINQToObjectsDemo5() 
        {
            var names = new List<string> { "Alice", "Andrew", "Bob", "Alex", "Charlie", "David", "Dalton", "Eve" };
            //Group by first letter using query syntax
            var groupedNamesQuery = from name in names
                                    group name by name[0] into nameGroup
                                    select new { FirstLetter = nameGroup.Key, Names = nameGroup.ToList() };
            // Display grouped names
            foreach (var group in groupedNamesQuery)
            {
                Console.WriteLine($"Names starting with '{group.FirstLetter}': {string.Join(", ", group.Names)}");
            }
        }

        private static void LINQToObjectsDemo6()
        {
            var numbers = Enumerable.Range(1, 10).ToList();
            // Calculate the sum & average using query syntax
            var sum = (from n in numbers select n).Sum();
            var average = (from n in numbers select n).Average();
            Console.WriteLine($"Sum: {sum}, Average: {average}");
        }

        private static void LINQToFilesDemo()
        {
            // Example: Reading lines from a text file and filtering them
            //var lines = File.ReadAllLines("Data.txt");
            var linesWithA = from line in File.ReadAllLines("Data.txt") //lines
                             where line.StartsWith("A")
                             orderby line
                             select line;
            Console.WriteLine("Lines starting with 'A':");
            foreach (var line in linesWithA)
            {
                Console.WriteLine(line);
            }
        }

        private static void LINQToCSVFilesDemo()
        {
            var employees = File.ReadAllLines("Employees.csv")
                .Skip(1) // Skip header line
                .Select(line => line.Split(','))
                .Select(parts => new
                {
                    Id = parts[0],
                    Name = parts[1],
                    Department = parts[2],
                    JobTitle= parts[3],
                    Location = parts[4],
                    Salary = decimal.Parse(parts[5])
                })
                .Where(emp => emp.Salary > 50000)
                .OrderBy(emp => emp.Salary);
            Console.WriteLine("Employees with Salary > 50000:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        private static void LINQToFilesDemo2()
        {
            // Count the words in the file data.txt using LINQ
            var wordCount = File.ReadAllLines("Data.txt")
                .SelectMany(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Count();

            Console.WriteLine($"Total word count: {wordCount}");    
        }

        private static void LINQToXmlDemo()
        {
            // Example: Reading and querying XML data using LINQ to XML
            //string xmlData = @"
            //<Employees>
            //    <Employee>
            //        <Id>1</Id>
            //        <Name>John Doe</Name>
            //        <Department>HR</Department>
            //        <Salary>60000</Salary>
            //    </Employee>
            //    <Employee>
            //        <Id>2</Id>
            //        <Name>Jane Smith</Name>
            //        <Department>IT</Department>
            //        <Salary>75000</Salary>
            //    </Employee>
            //    <Employee>
            //        <Id>3</Id>
            //        <Name>Mike Johnson</Name>
            //        <Department>Finance</Department>
            //        <Salary>50000</Salary>
            //    </Employee>
            //</Employees>";
            var xmlDoc = XDocument.Load("Data.xml");
            //var xmlDoc =XDocument.Parse(xmlData);
            var employees = from emp in xmlDoc.Descendants("Employee")
                        where (int)emp.Element("Salary") > 50000
                        select new
                        {
                            Name = emp.Element("Name").Value,
                            Department = emp.Element("Department").Value,
                            Salary = (int)emp.Element("Salary")
                        };
            Console.WriteLine("Employees with Salary > 50000:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }
    }
}
