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
        public void CreateTable()
        {
            using (var connection = new SqlConnection(connectionstring))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    IF NOT EXISTS CREATE TABLE Books(
                     BookId STRING PRIMARY KEY,
                        Title STRING NOL NULL,
                        Author STRING NOT NUL,
                        RentalPrice DECIMAL NOT NULL    );";
                command.ExecuteNonQuery();

            }
        }

        public void Insertdata()
        {

            using (var connection = new SqlConnection(connectionstring))
            {

                connection.Open();

                var insertcommand = connection.CreateCommand();
                insertcommand.CommandText = @"
                INSERT INTO Books(BookId,Title,Author,RentalPrice)  
                    VALUES('BOOK_001','jeans','Shangar',1.00);
                            ";
                insertcommand.ExecuteNonQuery();
            }
        }
    }
}
