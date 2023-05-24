using HotelManger.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entities
{
    public class BookRoom : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long Days { get; set; }
        public long Person { get; set; }
        [ForeignKey("Room")]
        public Guid RoomId  { get; set; }
        public virtual Room Room { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
