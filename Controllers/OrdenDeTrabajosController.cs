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

        public ActionResult Recibidos()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente).Where(o => o.TipoEstadoID == 1);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult EnProgreso()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente).Where(o => o.TipoEstadoID == 2);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Terminados()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente).Where(o => o.TipoEstadoID == 3);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Entregados()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente).Where(o => o.TipoEstadoID == 4);
            return View(ordendetrabajo.ToList());
        }
        public ActionResult Derivadas()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente).Where(o => o.TipoEstadoID == 5);
            return View(ordendetrabajo.ToList());
        }
                
    }
}
