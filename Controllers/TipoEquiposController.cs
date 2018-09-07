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
    public class TipoEquiposController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /TipoEquipos/
        public ActionResult Index()
        {
            return View(db.TipoEquipo.ToList());
        }

        // GET: /TipoEquipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // GET: /TipoEquipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoEquipos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,Activo")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEquipo);
        }

        // GET: /TipoEquipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: /TipoEquipos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,Activo")] TipoEquipo tipoEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEquipo);
        }

        // GET: /TipoEquipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            if (tipoEquipo == null)
            {
                return HttpNotFound();
            }
            return View(tipoEquipo);
        }

        // POST: /TipoEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEquipo tipoEquipo = db.TipoEquipo.Find(id);
            db.TipoEquipo.Remove(tipoEquipo);
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
