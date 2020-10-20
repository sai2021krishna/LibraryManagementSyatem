using System;
using System.Collections.Generic;

namespace JwtAuthenticationApi
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string BookAuthor { get; set; }
        public string BookName { get; set; }
        public int? BookEdition { get; set; }
    }
}
