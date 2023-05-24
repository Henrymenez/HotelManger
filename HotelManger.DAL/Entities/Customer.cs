using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.DAL.Entities
{
    public class Customer : BaseEntity
    {
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber  { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
