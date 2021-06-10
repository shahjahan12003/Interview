using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MvcMasterDetails.Model
{
    public class DataLayer
    {

        //public static string App_DataPath = HttpContext.Current.Server.MapPath("~/App_Data/");

        public static List<Employee> Employees = new List<Employee>();
        public static List<SalesHistory> SalesHistorys = new List<SalesHistory>();
        public static List<Car> Cars = new List<Car>();


        public static List<Employee> PopulateEmployees()
        {
            Employees.Clear();
            Employees = new List<Employee>
            {
                new Employee{ Id=1, Name="Anurag Gandhi", Email = "abc.zsa@gmail.com", Address = "This is a test Address.", Phone="99887782782", Gender='M'},
                new Employee{ Id=2, Name="Ramesh Kumar", Email = "ramesh.kumar@gmail.com", Address = "Ramesh Nagar, #34 C45, New Delhi.", Phone="910273573", Gender='M'},
                new Employee{ Id=3, Name="Radha Chaturvedi", Email = "radha.c@gmail.com", Address = "89, Delta Apartment, Peeniya, Bangalore", Phone="9487562746", Gender='M'}
            };
            return Employees;
        }

        public static List<Car> PopulateCars()
        {
            Cars.Clear();
            Cars = new List<Car>
            {
                new Car{ Id=1, Brand="Anurag Gandhi", Model = "abc.zsa@gmail.com", Make = 2009, SkuId="99887782782", City="M", IsSold = true, Price =350000},
                new Car{ Id=2, Brand="Ramesh Kumar", Model = "ramesh.kumar@gmail.com", Make = 2009, SkuId="99887782782", City="M", IsSold = true, Price =350000},
                new Car{ Id=3, Brand="Radha Chaturvedi", Model = "radha.c@gmail.com", Make = 2010, SkuId="99887782782", City="M", IsSold = true, Price =350000}
            };
            return Cars;
        }

        public static List<SalesHistory> PopulateSalesHistory()
        {
            SalesHistorys.Clear();
            string App_DataPath = HttpContext.Current.Server.MapPath("~/App_Data/");
            XDocument xdoc = XDocument.Load(App_DataPath + "SalesHistory.xml");

            //IEnumerable<XElement> elems = xdoc.Descendants("SalesHistory");

            SalesHistorys = xdoc.Descendants("SalesHistory").Select(x => new SalesHistory
            {
                Id = Convert.ToInt32(x.Attribute("Id").Value),
                ShopName = x.Attribute("ShopName").Value,
                ItemType = x.Attribute("ItemType").Value,
                ItemName = x.Attribute("ItemName").Value,
                CostPrice = Convert.ToDecimal(x.Attribute("CostPrice").Value),
                SellingPrice = Convert.ToDecimal(x.Attribute("SellingPrice").Value),
                SellingDate = Convert.ToDateTime(x.Attribute("SellingDate").Value),
                Quantity = Convert.ToInt32(x.Attribute("Quantity").Value)
            }).ToList();

            return SalesHistorys;
        }
    }
}