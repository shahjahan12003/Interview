using MvcMasterDetails.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMasterDetails.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        //Post action for Save data to database
        [HttpPost]
        public JsonResult SaveOrder(OrderVM O)
        {
            bool status = false;
            if (ModelState.IsValid)
            {

                // Order order = new Order { OrderNo = O.OrderNo, OrderDate = O.OrderDate, Description = O.Description };
                //  SaveOrder 
                int OrderID, OrderItemsID;



                string query = "INSERT INTO Orders VALUES(@OrderNo, @OrderDate,@Description)";
                query += "SELECT SCOPE_IDENTITY()";
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Parameters.AddWithValue("@OrderNo", O.OrderNo);
                        cmd.Parameters.AddWithValue("@OrderDate", O.OrderDate);
                        cmd.Parameters.AddWithValue("@Description", O.Description);
                        cmd.Connection = con;
                        con.Open();
                        OrderID = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }







                foreach (var i in O.OrderDetails)
                {
                    query = "INSERT INTO OrderDetails VALUES(@OrderID, @ItemName,@Quantity,@Rate,@TotalAmount)";
                    query += "SELECT SCOPE_IDENTITY()";

                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", OrderID);
                            cmd.Parameters.AddWithValue("@ItemName", i.ItemName);
                            cmd.Parameters.AddWithValue("@Quantity", i.Quantity);
                            cmd.Parameters.AddWithValue("@Rate", i.Rate);
                            cmd.Parameters.AddWithValue("@TotalAmount", i.TotalAmount);
                            cmd.Connection = con;
                            con.Open();
                            OrderItemsID = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }

                }
                status = true;
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
