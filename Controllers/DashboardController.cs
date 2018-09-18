using PCFIX.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            ViewBag.OrdenesRecibidasAtrasadas = db.OrdenDeTrabajo.Where(o => o.TipoEstadoID == 1 &&  DbFunctions.DiffDays(o.FechaIngreso, DateTime.Now) >= 2).Count();
            //4 Estado Entregado (Backup)
            ViewBag.EliminarBackup = db.OrdenDeTrabajo.Where(o => o.TipoEstadoID == 4 && DbFunctions.DiffDays(o.FechaEntrega, DateTime.Now) >= 10).Count();
            //3 Estado Abandonado (Abandonados)
            ViewBag.Abandonados = db.OrdenDeTrabajo.Where(o => o.TipoEstadoID == 3 && DbFunctions.DiffDays(o.FechaProblableEntrega, DateTime.Now) >= 90).Count();
            //5 Estado derivado Liberaciones
            ViewBag.Derivadas = db.OrdenDeTrabajo.Where(o => o.TipoEstadoID == 5 && DbFunctions.DiffDays(o.FechaIngreso, DateTime.Now) >= 7).Count();
            return View();
        }
        
    }
}