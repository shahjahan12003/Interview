﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMasterDetails.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}