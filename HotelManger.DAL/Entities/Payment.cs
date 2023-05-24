using HotelManger.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entities
{
    public class Payment : BaseEntity
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string TrxnRef { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Hotel")]
        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
