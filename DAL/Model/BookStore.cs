using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class BookStore
    {
        public int BookStoreId { get; set; }

        public int BookId { get; set; }

        public string? BookStatus { get; set; }

        public uint? BookEditionNumber { get; set; }  //KitapBaskıSayısı

        public string? BookPublishingHouse { get; set; }  //KitapBasımEvi

        public ushort? BookPageNumber{ get; set; }  //KitapSayfaSayısı

        public string? BookPhotoUrl { get; set; }   


        public Book Book { get; set; }

        public ICollection<UserBookStore> Users { get; set; }

        public ICollection<LibraryBookStore> Libraries { get; set; }
    }
}
