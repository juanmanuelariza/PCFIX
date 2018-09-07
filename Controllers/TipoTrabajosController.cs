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
    public class TipoTrabajosController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /TipoTrabajos/
        public ActionResult Index()
        {
            return View(db.TipoTrabajo.ToList());
        }

        // GET: /TipoTrabajos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = db.TipoTrabajo.Find(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // GET: /TipoTrabajos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoTrabajos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,Activo")] TipoTrabajo tipoTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.TipoTrabajo.Add(tipoTrabajo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTrabajo);
        }

        // GET: /TipoTrabajos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = db.TipoTrabajo.Find(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // POST: /TipoTrabajos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,Activo")] TipoTrabajo tipoTrabajo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTrabajo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTrabajo);
        }

        // GET: /TipoTrabajos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTrabajo tipoTrabajo = db.TipoTrabajo.Find(id);
            if (tipoTrabajo == null)
            {
                return HttpNotFound();
            }
            return View(tipoTrabajo);
        }

        // POST: /TipoTrabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTrabajo tipoTrabajo = db.TipoTrabajo.Find(id);
            db.TipoTrabajo.Remove(tipoTrabajo);
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
