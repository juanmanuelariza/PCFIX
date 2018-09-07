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
    public class TipoEstadosController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /TipoEstados/
        public ActionResult Index()
        {
            return View(db.TipoEstado.ToList());
        }

        // GET: /TipoEstados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstado tipoEstado = db.TipoEstado.Find(id);
            if (tipoEstado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstado);
        }

        // GET: /TipoEstados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoEstados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,Activo")] TipoEstado tipoEstado)
        {
            if (ModelState.IsValid)
            {
                db.TipoEstado.Add(tipoEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEstado);
        }

        // GET: /TipoEstados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstado tipoEstado = db.TipoEstado.Find(id);
            if (tipoEstado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstado);
        }

        // POST: /TipoEstados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,Activo")] TipoEstado tipoEstado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEstado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEstado);
        }

        // GET: /TipoEstados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstado tipoEstado = db.TipoEstado.Find(id);
            if (tipoEstado == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstado);
        }

        // POST: /TipoEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEstado tipoEstado = db.TipoEstado.Find(id);
            db.TipoEstado.Remove(tipoEstado);
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
