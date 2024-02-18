using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; } 
        public string UserLastName { get; set; }

        public string UserTcIdentityNo { get; set; }

        public DateTimeOffset? UserBirthDate { get; set; }

        public string? UserAdressCity { get; set; }

        public string? UserAdressDistrict { get; set; }

        public string? UserAdressPostalCode { get; set; }

        public string? UserAdressDetail { get; set; }

        public string UserPhoneNumber { get; set; }

        public string? UserEMail { get; set; }

        public string? UserStatus { get; set; }

        public string? UserPhotoUrl { get; set; }

        public ICollection<LibraryUser> Libraries { get; set; }

        public ICollection<UserBookStore> UserBookStores { get;}
    }
}
