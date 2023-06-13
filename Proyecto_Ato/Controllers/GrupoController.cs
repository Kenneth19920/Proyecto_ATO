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
    public class GrupoController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        // GET: Grupo
        public ActionResult Index()
        {
            var grupo = db.Grupo.Include(g => g.Estudiantes).Include(g => g.Horario);
            return View(grupo.ToList());
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "IdUsuario");
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Dia");
            return View();
        }

        // POST: Grupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGrupo,Descripcion,IdHorario,IdEstudiante")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupo.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "IdUsuario", grupo.IdEstudiante);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Dia", grupo.IdHorario);
            return View(grupo);
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "IdUsuario", grupo.IdEstudiante);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Dia", grupo.IdHorario);
            return View(grupo);
        }

        // POST: Grupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGrupo,Descripcion,IdHorario,IdEstudiante")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstudiante = new SelectList(db.Estudiantes, "IdEstudiante", "IdUsuario", grupo.IdEstudiante);
            ViewBag.IdHorario = new SelectList(db.Horario, "IdHorario", "Dia", grupo.IdHorario);
            return View(grupo);
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupo grupo = db.Grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupo grupo = db.Grupo.Find(id);
            db.Grupo.Remove(grupo);
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
