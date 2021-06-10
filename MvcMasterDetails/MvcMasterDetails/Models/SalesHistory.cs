using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMasterDetails.Model
{
    public class SalesHistory
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime SellingDate { get; set; }
        public int Quantity { get; set; }
    }
}