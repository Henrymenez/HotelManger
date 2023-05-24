using HotelManger.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.DAL.Entities
{
    public  class Room : BaseEntity
    {
        public RoomType RoomType { get; set; }
        public string RoomNumber {  get; set; }
        public string Floor { get; set;}
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set;}

        public string Facilities { get; set; }      

        public string FirstImage { get; set; }
        public string SecondImage { get; set; }
        public string? ThirdImage { get; set; }

        [ForeignKey("Hotel")]
        public Guid HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }

        [ForeignKey("Employee")]
        public Guid? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
