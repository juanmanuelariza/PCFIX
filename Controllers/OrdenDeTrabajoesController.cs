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
    public class OrdenDeTrabajoesController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /OrdenDeTrabajoes/
        public ActionResult Index()
        {
            var ordendetrabajo = db.OrdenDeTrabajo.Include(o => o.TipoEquipo).Include(o => o.TipoEstado).Include(o => o.TipoMarca).Include(o => o.TipoTrabajo).Include(o => o.Cliente);
            return View(ordendetrabajo.ToList());
        }

        // GET: /OrdenDeTrabajoes/Details/5
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

        // GET: /OrdenDeTrabajoes/Create
        public ActionResult Create()
        {
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre");
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre");
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre");
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre");
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido");
            return View();
        }

        // POST: /OrdenDeTrabajoes/Create
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
                return RedirectToAction("Index");
            }

            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido", ordenDeTrabajo.ClienteID);
            return View(ordenDeTrabajo);
        }

        // GET: /OrdenDeTrabajoes/Edit/5
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
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido", ordenDeTrabajo.ClienteID);
            return View(ordenDeTrabajo);
        }

        // POST: /OrdenDeTrabajoes/Edit/5
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
                return RedirectToAction("Index");
            }
            ViewBag.TipoEquipoID = new SelectList(db.TipoEquipo, "ID", "Nombre", ordenDeTrabajo.TipoEquipoID);
            ViewBag.TipoEstadoID = new SelectList(db.TipoEstado, "ID", "Nombre", ordenDeTrabajo.TipoEstadoID);
            ViewBag.TipoMarcaID = new SelectList(db.TipoMarca, "ID", "Nombre", ordenDeTrabajo.TipoMarcaID);
            ViewBag.TipoTrabajoID = new SelectList(db.TipoTrabajo, "ID", "Nombre", ordenDeTrabajo.TipoTrabajoID);
            ViewBag.ClienteID = new SelectList(db.Cliente, "ID", "Apellido", ordenDeTrabajo.ClienteID);
            return View(ordenDeTrabajo);
        }

        // GET: /OrdenDeTrabajoes/Delete/5
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

        // POST: /OrdenDeTrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDeTrabajo ordenDeTrabajo = db.OrdenDeTrabajo.Find(id);
            db.OrdenDeTrabajo.Remove(ordenDeTrabajo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
