using HotelManger.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.DAL.Entities
{
    public class Hotel : BaseEntity
    {
        public string  Name { get; set; }
        public string  PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        public string Email { get; set; }

        public string  website { get; set; }
        public string Facilities { get; set; }
        public HotelType HotelType { get; set; }
        public AccountType AccountType { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string? ThirdImage { get; set; }
        public virtual ICollection<Employee> employees { get; set; } = new List<Employee>();
        public virtual ICollection<Customer> customers { get; set; } = new List<Customer>();
        public virtual ICollection<Room> rooms { get; set; } = new List<Room>();
    }
}
