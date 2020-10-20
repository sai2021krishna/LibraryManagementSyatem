using System;
using System.Collections.Generic;

namespace lib_manag_sys
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string BookAuthor { get; set; }
        public string BookName { get; set; }
        public int? BookEdition { get; set; }
    }
}
