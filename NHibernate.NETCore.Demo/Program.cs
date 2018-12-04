using NHibernate.NETCore.Demo.Factory;
using NHibernate.NETCore.Demo.Models;
using NHibernate.NETCore.Demo.Repository;
using NHibernate.NETCore.Demo.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading;

namespace NHibernate.NETCore.Demo
{
    class Program
    {
        static IPersonRepository PersonRepository { get; set; }

        static DatabaseConnectorType DatabaseType = DatabaseConnectorType.MySQL;

        static string ConnectionString = "Server=mysql-server; Port=3306; Database=nhibernate; Uid=myuser; Pwd=mypass;";

        static void Main(string[] args)
        {
            Startup();

            char? option;
            do
            {
                option = GetOption(); 

                switch (option)
                {
                    case '1':
                        Console.WriteLine("Option 1 selected!");
                        Create();
                        break;
                    case '2':
                        Console.WriteLine("Option 2 selected!");
                        Update();
                        break;
                    case '3':
                        Console.WriteLine("Option 3 selected!");
                        Delete();
                        break;
                    case '4':
                        Console.WriteLine("Option 4 selected!");
                        Get();
                        break;
                    case '5':
                        Console.WriteLine("Option 5 selected!");
                        Search();
                        break;
                    case '6':
                        Console.WriteLine("Closing program...");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please, try again.");
                        break;
                }
            }
            while (option != '6');
        }

        static void Startup()
        {
            Console.WriteLine("NHibernate with .NET Core - demo!");
            Console.WriteLine();
            Console.WriteLine("-> https://github.com/ThiagoBarradas/nhibernate-netcore-demo");
            Console.WriteLine();

            var sessionFactory = DatabaseConnectorFactory.GetInstance(DatabaseType, ConnectionString);
            PersonRepository = new PersonRepository(sessionFactory);
        }

        static char GetOption()
        {
            Console.WriteLine();
            Console.WriteLine("# MENU");
            Console.WriteLine("1 - Create new person");
            Console.WriteLine("2 - Update person");
            Console.WriteLine("3 - Delete person");
            Console.WriteLine("4 - Get person");
            Console.WriteLine("5 - Search person by name");
            Console.WriteLine("6 - Exit");
            Console.WriteLine();
            Console.Write("Please, insert option number: ");
            var option = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine();

            return option;
        }

        static void Create()
        {
            Person person = new Person();

            Console.WriteLine();
            Console.WriteLine("# Create new person");
            Console.WriteLine();
            
            Console.Write("Document: ");
            person.Document = Console.ReadLine();

            Console.Write("Name: ");
            person.Name = Console.ReadLine();

            var result = PersonRepository.Create(person);

            var message = (result == true) 
                ? "Successful! :)" 
                : "Failed!";

            Console.WriteLine(message);
        }

        static void Update()
        {
            Person person = new Person();

            Console.WriteLine();
            Console.WriteLine("# Update person");
            Console.WriteLine();

            Console.Write("Document (must exists): ");
            person.Document = Console.ReadLine();

            Console.Write("Name: ");
            person.Name = Console.ReadLine();

            var result = PersonRepository.Update(person);

            var message = (result == true)
                ? "Successful! :)"
                : "Failed!";

            Console.WriteLine(message);
        }

        static void Delete()
        {
            Console.WriteLine();
            Console.WriteLine("# Delete person");
            Console.WriteLine();

            Console.Write("Document (must exists): ");
            var document = Console.ReadLine();
            
            var result = PersonRepository.Delete(document);

            var message = (result == true)
                ? "Successful! :)"
                : "Failed!";

            Console.WriteLine(message);
        }

        static void Get()
        {
            Console.WriteLine();
            Console.WriteLine("# Get person");
            Console.WriteLine();

            Console.Write("Document (must exists): ");
            var document = Console.ReadLine();

            var person = PersonRepository.Get(document);

            if (person != null)
            {
                Console.WriteLine(" Document: {0}\n Name: {1}", person.Document, person.Name);
            }
            else
            {
                Console.WriteLine("Person not found!");
            }
        }

        static void Search()
        {
            Console.WriteLine();
            Console.WriteLine("# Search person by name");
            Console.WriteLine();

            Console.Write("Keyword: ");
            var keyword = Console.ReadLine();

            var persons = PersonRepository
                .Search(person => person.Name.ToLower().Contains(keyword.ToLower()));

            if (persons?.Any() == true)
            {
                persons.ToList().ForEach(person =>
                {
                    Console.WriteLine(" Document: {0}\n Name: {1}", person.Document, person.Name);
                    Console.WriteLine();
                });
            }
            else
            {
                Console.WriteLine("Empty result!");
            }
        }
    }
}
