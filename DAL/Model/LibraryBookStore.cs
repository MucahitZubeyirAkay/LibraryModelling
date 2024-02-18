using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class LibraryBookStore
    {
        public int LibraryId { get; set; }

        public int BookStoreId { get; set; }

        public Library Library { get; set; }

        public BookStore BookStore { get; set; }
    }
}
