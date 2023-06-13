using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Ato.Models;

namespace Proyecto_Ato.Controllers
{
    [Authorize]
    public class CategoriaGastosController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        // GET: CategoriaGastos
        public ActionResult Index()
        {
            return View(db.CategoriaGastos.ToList());
        }

        // GET: CategoriaGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGastos categoriaGastos = db.CategoriaGastos.Find(id);
            if (categoriaGastos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGastos);
        }

        // GET: CategoriaGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaGastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,Descripcion,FechaCreacion")] CategoriaGastos categoriaGastos)
        {
            if (ModelState.IsValid)
            {
                categoriaGastos.FechaCreacion = DateTime.Now;
                db.CategoriaGastos.Add(categoriaGastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaGastos);
        }

        // GET: CategoriaGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGastos categoriaGastos = db.CategoriaGastos.Find(id);
            if (categoriaGastos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGastos);
        }

        // POST: CategoriaGastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoria,Descripcion,FechaCreacion")] CategoriaGastos categoriaGastos)
        {
            if (ModelState.IsValid)
            {
                categoriaGastos.FechaCreacion = DateTime.Now;
                db.Entry(categoriaGastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaGastos);
        }

        // GET: CategoriaGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaGastos categoriaGastos = db.CategoriaGastos.Find(id);
            if (categoriaGastos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaGastos);
        }

        // POST: CategoriaGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaGastos categoriaGastos = db.CategoriaGastos.Find(id);
            db.CategoriaGastos.Remove(categoriaGastos);
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
