﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.DAL.Configurations
{
    public class JwtConfig
    {
        public string  Secret { get; set; }
        public TimeSpan ExpiryTimeFrame { get; set; }
    }
}
