using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class Library
    {
        public int LibraryId { get; set; }

        public string LibraryName { get; set; }

        public string? LibraryAdressCity { get; set; }

        public string? LibraryAdressDistrict { get; set; }

        public string? LibraryAdressPostalCode { get; set; }

        public string? LibraryAdressDetail { get; set; }

        public string? LibraryPhoneNumber { get; set; }

        public string? LibraryStatus { get; set; }

        public ICollection<LibraryBookStore> BookStores { get; set; }

        public ICollection<LibraryUser> Users { get; set; }

    }
}
