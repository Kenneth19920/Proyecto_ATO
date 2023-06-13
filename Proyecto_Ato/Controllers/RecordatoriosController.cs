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
    public class RecordatoriosController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        // GET: Recordatorios
        public ActionResult Index()
        {
            var recordatorios = db.Recordatorios.Include(r => r.AspNetUsers);
            return View(recordatorios.ToList());
        }

        // GET: Recordatorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recordatorios recordatorios = db.Recordatorios.Find(id);
            if (recordatorios == null)
            {
                return HttpNotFound();
            }
            return View(recordatorios);
        }

        // GET: Recordatorios/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Recordatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRecordatorio,IdUsuario,Descripcion,Fecha")] Recordatorios recordatorios)
        {
            if (ModelState.IsValid)
            {
                db.Recordatorios.Add(recordatorios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", recordatorios.IdUsuario);
            return View(recordatorios);
        }

        // GET: Recordatorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recordatorios recordatorios = db.Recordatorios.Find(id);
            if (recordatorios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", recordatorios.IdUsuario);
            return View(recordatorios);
        }

        // POST: Recordatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRecordatorio,IdUsuario,Descripcion,Fecha")] Recordatorios recordatorios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recordatorios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", recordatorios.IdUsuario);
            return View(recordatorios);
        }

        // GET: Recordatorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recordatorios recordatorios = db.Recordatorios.Find(id);
            if (recordatorios == null)
            {
                return HttpNotFound();
            }
            return View(recordatorios);
        }

        // POST: Recordatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recordatorios recordatorios = db.Recordatorios.Find(id);
            db.Recordatorios.Remove(recordatorios);
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
