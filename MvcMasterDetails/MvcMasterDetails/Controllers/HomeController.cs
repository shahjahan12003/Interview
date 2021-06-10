using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMasterDetails.Model;
using MvcMasterDetails.Models;

namespace MvcMasterDetails.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RawReport()
        {

            return View(DataLayer.PopulateEmployees());
        }

        public ActionResult ReportWithOptions()
        {
            return View(DataLayer.PopulateEmployees());
        }

        public ActionResult ReportWithPivot()
        {
            return View(DataLayer.PopulateSalesHistory());
        }


        public ActionResult WithReportColumn()
        {
            return View(DataLayer.PopulateSalesHistory());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
