using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.DAL.Entities
{
    public  class Employee : BaseEntity
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        [ForeignKey("Hotel")]
        public Guid HotelID { get; set; }
        public Hotel Hotel { get; set; }
    }
}
