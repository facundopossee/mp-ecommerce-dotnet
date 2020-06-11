﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_ecommerce.Models
{
    public class Notification
    {
        public int id { get; set; }
        public bool live_mode { get; set; }
        public DateTime date_created { get; set; }
        public int application_id { get; set; }
        public int user_id { get; set; }
        public int version { get; set; }
        public string api_version { get; set; }
        public string action { get; set; }
        public object data { get; set; }
    }
}