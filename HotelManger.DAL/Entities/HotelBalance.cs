using HotelManger.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Entities
{
    public class HotelBalance : BaseEntity
    {
        public decimal NairaBalance { get; set; } = default;

        [ForeignKey("Hotel")]
        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }    
    }
}
