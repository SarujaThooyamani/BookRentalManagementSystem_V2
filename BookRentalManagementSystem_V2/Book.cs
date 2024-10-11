using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem_V2
{
    internal class Book
    {
        public string Bookid {  get; set; }
        public string Title {  get; set; }
        public string Author{  get; set; }
        public decimal RentalPrice {  get; set; }

        public Book(string bookid, string title, string author, decimal rentalPrice)
        {
            Bookid = bookid;
            Title = title;
            Author = author;
            RentalPrice = rentalPrice;
        }

        public Book()
        {
        }
    }
}
