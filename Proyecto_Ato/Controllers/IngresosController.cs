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
    
    public class IngresosController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();
        private string userId;

        
        public int ObtenerNumeroIngresos()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            int count = db.Ingresos.Count();
            return count > 0 ? count : 0;
        }
        public DateTime ObtenerFechaUltimoIngreso()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            DateTime? ultimaFecha = db.Ingresos.OrderByDescending(i => i.FechaIngreso).Select(i => i.FechaIngreso).FirstOrDefault();
            return ultimaFecha ?? DateTime.MinValue;
        }

        public decimal ObtenerTotalMontos()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            decimal sumaMontos = db.Ingresos.Select(i => i.Monto).DefaultIfEmpty(0).Sum();
            return sumaMontos;

        }

        // GET: Ingresos
        public ActionResult Index()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            var ingresos = db.Ingresos.Where(i => i.IdUsuario == user.Id);
            return View(ingresos.ToList());
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdCategoria = new SelectList(db.CategoriaIngresos, "IdCategoria", "Descripcion");
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdIngreso,IdUsuario,IdCategoria,Descripcion,Monto,FechaIngreso")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                ingresos.IdUsuario = user.Id;
                db.Ingresos.Add(ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", ingresos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaIngresos, "IdCategoria", "Descripcion", ingresos.IdCategoria);
            return View(ingresos);
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", ingresos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaIngresos, "IdCategoria", "Descripcion", ingresos.IdCategoria);
            return View(ingresos);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdIngreso,IdUsuario,IdCategoria,Descripcion,Monto,FechaIngreso")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                ingresos.IdUsuario = user.Id;
                db.Entry(ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", ingresos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaIngresos, "IdCategoria", "Descripcion", ingresos.IdCategoria);
            return View(ingresos);
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            Ingresos ingresos = db.Ingresos.Find(id);
            db.Ingresos.Remove(ingresos);
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
