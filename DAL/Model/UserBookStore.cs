using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class UserBookStore
    {
        
            public int UserId { get; set; }

            public int BookStoreId { get; set; }

            public DateTime BookReceiveDate { get; set; } //Kitap teslim alındığı zaman.

            public DateTime BookDeliveryTime { get; set; } //Kitap teslim edileceği zaman.

            public DateTime? BookDeliveredDate { get; set; } //Kitap teslim edilen zaman.

            public BookStore BookStore { get; set; }

            public User User { get; set; }

    }
}
