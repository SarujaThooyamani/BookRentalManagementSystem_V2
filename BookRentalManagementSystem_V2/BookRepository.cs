using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class BookRepository
    {
        public string connectionstring = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=BookRentalManagement;Integrated Security=True";

        public void CreateBook(Book book)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                    INSERT INTO Books(BookId,Title,Author,RentalPrice) VALUES
                    (@BookId,@Title,@Author,@RentalPrice);
                                        ";
                    command.Parameters.AddWithValue("@BookId", book.Bookid);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book Successfully added in database");

                }

            }
            catch (SqlException Sqlex)
            {
                Console.WriteLine(Sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public List<Book> GetAllData()
        {
            var books = new List<Book>();
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                           SELECT * FROM Books ";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var book = new Book(
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3)
                                );
                            books.Add(book);
                        }
                    }
                }

            }
            catch (SqlException Sqlex)
            {
                Console.WriteLine(Sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return books;
        }

        public void GetsingleData(string bookid)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                       SELECT FROM Books
                         WHERE BookId=@BookId";
                    command.Parameters.AddWithValue("@BookId", bookid);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var book = new Book(
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3)

                                );
                        }
                    }
                }
            }
            catch (SqlException Sqlex)
            {
                Console.WriteLine(Sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateBook(Book book)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                     UPDATE Books 
                        SET Title=@Title,
                          Author=@Author,
                           RentalPrice=@RentalPrice  
                        WHERE BookId=@ BookId";
                    command.Parameters.AddWithValue("@BookId", book.Bookid);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    command.ExecuteNonQuery();
                    Console.WriteLine("BookUpdated in database successfully");

                }

            }
            catch (SqlException Sqlex)
            {
                Console.WriteLine(Sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteBook(string bookId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"
                       DELETE FROM Books
                         WHERE BookId= @BookId       ";
                    command.Parameters.AddWithValue("@BookId", bookId);
                    Console.WriteLine("Book Deleted sucssesfully");
                }
            }
            catch (SqlException Sqlex)
            {
                Console.WriteLine(Sqlex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public string CapitalizeTitle(Book book)
        {
            try
            {
                var word= book.Title.Split(' ');
                for(int i=0; i<word.Length; i++)
                {
                    word[i] = char.ToUpper(word[i][0]) + word[i].Substring(1).ToLower();
                }
                book.Title=String.Join(" ", word);
                return book.Title;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return book.Title;
        }
    }
}
