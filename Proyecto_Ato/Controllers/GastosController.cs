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
    public class GastosController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();
        private string userId;

        public int ObtenerNumeroGastos()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            int count = db.Gastos.Count();
            return count > 0 ? count : 0;
        }
        public string ObtenerFechaUltimoGasto()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            DateTime? ultimaFecha = db.Gastos.OrderByDescending(i => i.FechaIngreso).Select(i => i.FechaIngreso).FirstOrDefault();
            return ultimaFecha.HasValue ? ultimaFecha.Value.ToString("dd/MM/yyyy") : string.Empty;
        }

        public string ObtenerTotalMontoGasto()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            decimal sumaMontos = db.Gastos.Select(i => i.Monto).DefaultIfEmpty(0).Sum();
            return string.Format("{0:N}", sumaMontos);

        }

        // GET: Gastos
        public ActionResult Index()
        {
            var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
            var gastos = db.Gastos.Include(g => g.AspNetUsers).Include(g => g.CategoriaGastos);
            return View(gastos.ToList());
        }

       

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdCategoria = new SelectList(db.CategoriaGastos, "IdCategoria", "Descripcion");
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGastos,IdUsuario,IdCategoria,Descripcion,Monto,FechaIngreso")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                gastos.IdUsuario = user.Id;
                db.Gastos.Add(gastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", gastos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaGastos, "IdCategoria", "Descripcion", gastos.IdCategoria);
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", gastos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaGastos, "IdCategoria", "Descripcion", gastos.IdCategoria);
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGastos,IdUsuario,IdCategoria,Descripcion,Monto,FechaIngreso")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                gastos.IdUsuario = user.Id;
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", gastos.IdUsuario);
            ViewBag.IdCategoria = new SelectList(db.CategoriaGastos, "IdCategoria", "Descripcion", gastos.IdCategoria);
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gastos gastos = db.Gastos.Find(id);
            db.Gastos.Remove(gastos);
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
