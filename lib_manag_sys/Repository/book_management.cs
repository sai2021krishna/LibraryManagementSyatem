using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lib_manag_sys.Repository
{
    public class book_management:Ibook_management
    {
        Library_management_systemContext b1 = new Library_management_systemContext();
        public book_management(Library_management_systemContext context)
        {
            b1 = context;
        }

        public IEnumerable<Books> GetAllBooks()
        {
            var booklist = from book in b1.Books select book;
            return booklist.ToList();
        }
        public Books GetBookWithId(int id)
        {
            var bok = b1.Books.SingleOrDefault(x=>x.BookId==id);
            return bok;
        }
        public bool AddNewBook(Books book)
        {
            if (book.BookEdition != null && book.BookAuthor != null && book.BookName != null)
            {
                b1.Books.Add(book);
                b1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateBook(int id, Books updated_values)
        {
            Books b = b1.Books.SingleOrDefault(book => book.BookId == id);
            if (b != null)
            {
                b.BookAuthor = updated_values.BookAuthor;
                b.BookName = updated_values.BookName;
                b.BookEdition = updated_values.BookEdition;
                b1.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteExistingBook(int id)
        {

            var b = b1.Books.SingleOrDefault(book => book.BookId == id);
            if (b != null)
            {
                b1.Remove(b);
                b1.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
