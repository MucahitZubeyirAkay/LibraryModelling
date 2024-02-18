using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModelling.DAL.Model
{
    public class LibraryUser
    {
        public int LibraryId { get; set; }

        public int UserId { get; set; }

        public Library Library { get; set; }

        public User User { get; set; }
    }
}
