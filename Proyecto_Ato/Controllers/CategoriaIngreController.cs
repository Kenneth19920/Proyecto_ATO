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
    public class CategoriaIngreController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();


        public int ObtenerNumeroCategoriasIn()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            int count = db.CategoriaIngresos.Count();
            return count > 0 ? count : 0;
        }

        public DateTime ObtenerFechaUltimoCategoriaIn()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            DateTime? ultimaFecha = db.CategoriaIngresos.OrderByDescending(i => i.FechaCreacion).Select(i => i.FechaCreacion).FirstOrDefault();
            return ultimaFecha ?? DateTime.MinValue;
        }


        // GET: CategoriaIngre
        public ActionResult Index()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);        
            var categoriaIngresos = db.Ingresos.Where(i => i.IdUsuario == user.Id);
            return View(db.CategoriaIngresos.ToList());

        }

        // GET: CategoriaIngre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaIngresos categoriaIngresos = db.CategoriaIngresos.Find(id);
            if (categoriaIngresos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaIngresos);
        }

        // GET: CategoriaIngre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaIngre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,Descripcion,FechaCreacion")] CategoriaIngresos categoriaIngresos)
        {
            if (ModelState.IsValid)
            {
                categoriaIngresos.FechaCreacion = DateTime.Now;
                db.CategoriaIngresos.Add(categoriaIngresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriaIngresos);
        }

        // GET: CategoriaIngre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaIngresos categoriaIngresos = db.CategoriaIngresos.Find(id);
            if (categoriaIngresos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaIngresos);
        }

        // POST: CategoriaIngre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoria,Descripcion,FechaCreacion")] CategoriaIngresos categoriaIngresos)
        {
            if (ModelState.IsValid)
            {
                categoriaIngresos.FechaCreacion = DateTime.Now;
                db.Entry(categoriaIngresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriaIngresos);
        }

        // GET: CategoriaIngre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaIngresos categoriaIngresos = db.CategoriaIngresos.Find(id);
            if (categoriaIngresos == null)
            {
                return HttpNotFound();
            }
            return View(categoriaIngresos);
        }

        // POST: CategoriaIngre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaIngresos categoriaIngresos = db.CategoriaIngresos.Find(id);
            db.CategoriaIngresos.Remove(categoriaIngresos);
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
