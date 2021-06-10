using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMasterDetails.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Make { get; set; }
        public string SkuId { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
        public bool IsSold { get; set; }
    }
}