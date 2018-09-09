using PCFIX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCFIX.Controllers
{
    public class DashboardController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();
        public ActionResult Index()
        {
            ViewBag.OrdenesRecibidasAtrasadas = db.OrdenDeTrabajo.Where(o => o.FechaIngreso > DateTime.Now).Count();
            return View();
        }
        
    }
}