using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PCFIX.Models;

namespace PCFIX.Controllers
{
    public class OrdenDeTrabajosController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /OrdenDeTrabajos/
        public ActionResult Index()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente);
            return View(ordendetrabajo.ToList());
        }

        // GET: /OrdenDeTrabajos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            if (ordenDeTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(ordenDeTrabajo);
        }

        // GET: /OrdenDeTrabajos/Create
        public ActionResult Create(int? id)
        {
            Cliente cliente = db.Cliente.Find(id);
            ViewBag.ClienteID = cliente.ID;
            ViewBag.ClienteNombre = cliente.Apellido + ", " +cliente.Nombre;
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre");
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre");
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre");
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre");
            return View();
        }

        // POST: /OrdenDeTrabajos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ClienteID,FechaIngreso,FechaProblableEntrega,FechaEntrega,TipoEstadoID,TipoEquipoID,TipoMarcaID,Caracteristicas,TipoTrabajoID,Observaciones")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDeTrabajo.Add(ordenDeTrabajo);
                db.SaveChanges();
                return RedirectToAction("../Clientes/Details/" + ordenDeTrabajo.ClienteID);
            }

            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido", ordenDeTrabajo.ClienteID);
            return View(ordenDeTrabajo);
        }

        // GET: /OrdenDeTrabajos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            if (ordenDeTrabajo == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ClienteID = ordenDeTrabajo.ClienteID;
            ViewBag.ClienteNombre = ordenDeTrabajo.Cliente.Apellido+ ", " + ordenDeTrabajo.Cliente.Nombre;
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            
            return View(ordenDeTrabajo);
        }

        // POST: /OrdenDeTrabajos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ClienteID,FechaIngreso,FechaProblableEntrega,FechaEntrega,TipoEstadoID,TipoEquipoID,TipoMarcaID,Caracteristicas,TipoTrabajoID,Observaciones")] OrdenDeTrabajo ordenDeTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDeTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../Clientes/Details/" + ordenDeTrabajo.ClienteID);
            }
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido", ordenDeTrabajo.ClienteID);
            return View(ordenDeTrabajo);
        }

        // GET: /OrdenDeTrabajos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            if (ordenDeTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(ordenDeTrabajo);
        }

        // POST: /OrdenDeTrabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            db.OrdenDeTrabajo.Remove(ordenDeTrabajo);
            db.SaveChanges();
            return RedirectToAction("../Clientes/Details/" + ordenDeTrabajo.ClienteID);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        public ActionResult CambiarEstado(int? id)
        {
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            ViewBag.ClienteID = ordenDeTrabajo.ClienteID;
            ViewBag.ClienteNombre = ordenDeTrabajo.Cliente.Apellido + ", " + ordenDeTrabajo.Cliente.Nombre;
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            return View(ordenDeTrabajo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarEstado(OrdenDeTrabajo ordenDeTrabajo)
        {            
            db.Entry(ordenDeTrabajo).State = EntityState.Modified;
            if (ordenDeTrabajo.TipoEstadoID == 4)
            {
                ordenDeTrabajo.FechaEntrega = DateTime.Now;
            }
            db.SaveChanges();
            return RedirectToAction("../Clientes/Details/" + ordenDeTrabajo.ClienteID);
        }

        public ActionResult Recibidos(int? alerta)
        {
            IQueryable<OrdenDeTrabajo> ordendetrabajo;
            switch (alerta)
            {
                case 1:
                    //Alerta Recibidos hace más de 2 dias
                    ViewBag.Titulo = "Recibidos hace más de 2 dias";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 1 && DbFunctions.DiffDays(o.FechaIngreso, DateTime.Now) >= 2);
                    break;
                default:
                    //Si NULL o cualquier valor, mostramos listado original
                    ViewBag.Titulo = "Recibidas";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 1);
                    break;
            }
            return View(ordendetrabajo.ToList());
        }
         public ActionResult EnProgreso()
        {
            ViewBag.Titulo = "En Progreso";
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                .Where(o => o.TipoEstadoID == 2);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Terminados(int? alerta)
        {
            ViewBag.Titulo = "Terminadas";
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                .Where(o => o.TipoEstadoID == 3);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Entregados(int? alerta)
        {
            IQueryable<OrdenDeTrabajo> ordendetrabajo;
            switch (alerta)
            {
                case 1:
                    //Alerta BackUps (más de 10 días)
                    ViewBag.Titulo = "Eliminar Backup";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 4 && DbFunctions.DiffDays(o.FechaEntrega, DateTime.Now) >= 10);
                    break;
                default:
                    //Si NULL o cualquier valor, mostramos listado original
                    ViewBag.Titulo = "Entregadas";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 4);
                    break;
            }            
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Derivadas(int? alerta)
        {
            IQueryable<OrdenDeTrabajo> ordendetrabajo;
            switch (alerta)
            {
                case 1:
                    //Derivadas más de 7 días
                    ViewBag.Titulo = "Derivadas 7 días o más";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 5 && DbFunctions.DiffDays(o.FechaIngreso, DateTime.Now) >= 7);
                    break;
                default:
                    //Si NULL o cualquier valor, mostramos listado original
                    ViewBag.Titulo = "Derivadas";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 5);
                    break;
            }
            return View(ordendetrabajo.ToList());
        }

        public ActionResult Abandonada(int? alerta)
        {
            IQueryable<OrdenDeTrabajo> ordendetrabajo;
            switch (alerta)
            {
                case 1:
                    //Abandonada más de 90 días
                    ViewBag.Titulo = "Abandonadas 90 días o más de la fecha probable de entrega";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 6 && DbFunctions.DiffDays(o.FechaProblableEntrega, DateTime.Now) >= 90);
                    break;
                default:
                    //Si NULL o cualquier valor, mostramos listado original
                    ViewBag.Titulo = "Abandonadas";
                    ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                        .Where(o => o.TipoEstadoID == 6);
                    break;
            }
            return View(ordendetrabajo.ToList());            
        }

        public ActionResult EsperandoRepuesto()
        {
            ViewBag.Titulo = "Esperando Repuesto";
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                .Where(o => o.TipoEstadoID == 7);
            return View(ordendetrabajo.ToList());
        }

        public ActionResult Archivada()
        {
            ViewBag.Titulo = "Archivadas";
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente)
                .Where(o => o.TipoEstadoID == 8);
            return View(ordendetrabajo.ToList());
        }
    }
}
