using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManger.DAL.Entities
{
    public class AppRole: IdentityRole
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
       /* public bool Active { get; set; } = true;*/

        public virtual ICollection<AppUserRole> UserRoles { get; set; }
     
    }
}
