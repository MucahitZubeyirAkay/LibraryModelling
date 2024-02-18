using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class AuthorCategory
    {
        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public Author Author { get; set; }

        public Category Category { get; set; }
    }
}
