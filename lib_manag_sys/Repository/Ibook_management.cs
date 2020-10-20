using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lib_manag_sys.Repository
{
    public interface Ibook_management
    {
        IEnumerable<Books> GetAllBooks();
        Books GetBookWithId(int id);
        bool AddNewBook(Books book);
        bool UpdateBook(int id, Books updated_values);
        bool DeleteExistingBook(int id);
    }
}
