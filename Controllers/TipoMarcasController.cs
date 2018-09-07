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
    public class TipoMarcasController : Controller
    {
        private PCFIXEntities db = new PCFIXEntities();

        // GET: /TipoMarcas/
        public ActionResult Index()
        {
            return View(db.TipoMarca.ToList());
        }

        // GET: /TipoMarcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMarca tipoMarca = db.TipoMarca.Find(id);
            if (tipoMarca == null)
            {
                return HttpNotFound();
            }
            return View(tipoMarca);
        }

        // GET: /TipoMarcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoMarcas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nombre,Activo")] TipoMarca tipoMarca)
        {
            if (ModelState.IsValid)
            {
                db.TipoMarca.Add(tipoMarca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoMarca);
        }

        // GET: /TipoMarcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMarca tipoMarca = db.TipoMarca.Find(id);
            if (tipoMarca == null)
            {
                return HttpNotFound();
            }
            return View(tipoMarca);
        }

        // POST: /TipoMarcas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nombre,Activo")] TipoMarca tipoMarca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoMarca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoMarca);
        }

        // GET: /TipoMarcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMarca tipoMarca = db.TipoMarca.Find(id);
            if (tipoMarca == null)
            {
                return HttpNotFound();
            }
            return View(tipoMarca);
        }

        // POST: /TipoMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoMarca tipoMarca = db.TipoMarca.Find(id);
            db.TipoMarca.Remove(tipoMarca);
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
