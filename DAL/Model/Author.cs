using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorLastName { get; set; }

        public DateTimeOffset? AuthorBirthDate { get; set; }

        public string? AuthorCountry { get; set; }

        public string? AuthorPhotoUrl { get; set; }

        public ICollection<BookAuthor> Books {  get; set; }    

        public ICollection<AuthorCategory> Categories { get; set; } 
    }
}
