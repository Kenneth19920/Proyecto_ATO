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
    public class EstudiantesController : Controller
    {
        private Academia_AtoEntities db = new Academia_AtoEntities();

        // GET: Estudiantes
        public ActionResult Index()
        {
            var estudiantes = db.Estudiantes.Include(e => e.AspNetUsers);
            return View(estudiantes.ToList());
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstudiante,IdUsuario,Nombre,PrimerApellido,SegundoApellido,Cedula,FechaNacimiento,Edad,Genero,Peso,Altura,Direccion,Telefono,Correo,HistorialMedico")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                estudiantes.IdUsuario = user.Id;
                db.Estudiantes.Add(estudiantes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", estudiantes.IdUsuario);
            return View(estudiantes);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", estudiantes.IdUsuario);
            return View(estudiantes);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstudiante,IdUsuario,Nombre,PrimerApellido,SegundoApellido,Cedula,FechaNacimiento,Edad,Genero,Peso,Altura,Direccion,Telefono,Correo,HistorialMedico")] Estudiantes estudiantes)
        {
            if (ModelState.IsValid)
            {
                var user = db.AspNetUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                estudiantes.IdUsuario = user.Id;
                db.Entry(estudiantes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.AspNetUsers, "Id", "Email", estudiantes.IdUsuario);
            return View(estudiantes);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            if (estudiantes == null)
            {
                return HttpNotFound();
            }
            return View(estudiantes);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiantes estudiantes = db.Estudiantes.Find(id);
            db.Estudiantes.Remove(estudiantes);
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
