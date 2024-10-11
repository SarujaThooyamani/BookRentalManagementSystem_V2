using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository();
            int option;
            do
            {
                Console.WriteLine("Book Rental Management System");
                Console.WriteLine("1 Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4 .Delete a Book");
                Console.WriteLine("5. exit");
                Console.WriteLine("Choose an option");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Choose an option:1 ");
                        Console.WriteLine("Enter Book ID");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter Book Title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter Book Author");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter rental price:");
                        decimal price = Decimal.Parse(Console.ReadLine());
                       bookRepository.CreateBook(new Book(id, title, author, price));
                        break;
                    case 2:
                        Console.WriteLine("Choose an option: 2");
                    var data=    bookRepository.GetAllData();
                        foreach (var item in data)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 3:
                        Console.WriteLine("Choose an option: 3");
                        Console.WriteLine("Enter the bookId to update");
                        string newId = Console.ReadLine();
                        Console.WriteLine("Enter new Title");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("Enter new Author");
                        string newAuthor = Console.ReadLine();
                        Console.WriteLine("Enter new RentalPrice");
                        decimal newPrice = Decimal.Parse(Console.ReadLine());
                       bookRepository.UpdateBook(new Book(newId, newTitle, newAuthor, newPrice));   
                        break;
                    case 4:
                        Console.WriteLine("Choose an option: 4");
                        Console.WriteLine("Enter BookId to delete");
                        string dltId = Console.ReadLine();
                        bookRepository.DeleteBook(dltId);
                        break;
                    case 5:
                        Console.WriteLine("Existing......");
                        break;
                    default:
                        Console.WriteLine("Enter valid number");
                        break;
                }
            } while (option != 5);
        }
    }
    
}
