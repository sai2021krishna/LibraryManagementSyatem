using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Client.Models
{
    public class BookViewModel
    {
        [Key]
        [Display(Name = "Book Id")]
        public int bookId { get; set; }
        [Display(Name ="Book Author")]
        public string bookAuthor { get; set; }
        [Display(Name = "Book Name")]
        public string bookName { get; set; }
        [Display(Name = "Book Edition")]
        public int bookEdition { get; set; }
    }
}
