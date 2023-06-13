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
    public class HorariosController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        // GET: Horarios
        public ActionResult Index()
        {

            return View(db.Horario.ToList());
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHorario,Dia,Tiempo,Hora")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horario);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHorario,Dia,Tiempo,Hora")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            db.Horario.Remove(horario);
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
