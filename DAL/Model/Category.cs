using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<BookCategory> Books { get; set; }

        public ICollection<AuthorCategory> Authors { get; set; }
    }
}
