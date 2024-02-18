using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class Book
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public DateTime? BookFirstTimeOfPublication { get; set; }

        public ICollection<BookStore> BookStores { get; set; }

        public ICollection<BookCategory> Categories { get; set; } 

        public ICollection<BookAuthor> Authors { get; set; }
    }
}
