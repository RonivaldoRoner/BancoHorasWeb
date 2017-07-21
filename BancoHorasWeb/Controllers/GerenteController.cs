using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BancoHorasWeb.Models;

namespace BancoHorasWeb.Controllers
{
    public class GerenteController : Controller
    {
        private BancoHorasWebContext db = new BancoHorasWebContext();

        // GET: Gerente
        public ActionResult Index()
        {
            var gerentes = db.Gerentes.Include(g => g.Funcionario);
            return View(gerentes.ToList());
        }

        // GET: Gerente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return HttpNotFound();
            }
            return View(gerente);
        }

        // GET: Gerente/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF");
            return View();
        }

        // POST: Gerente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GerenteId,FuncionarioId")] Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                db.Gerentes.Add(gerente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", gerente.FuncionarioId);
            return View(gerente);
        }

        // GET: Gerente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", gerente.FuncionarioId);
            return View(gerente);
        }

        // POST: Gerente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GerenteId,FuncionarioId")] Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", gerente.FuncionarioId);
            return View(gerente);
        }

        // GET: Gerente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerente gerente = db.Gerentes.Find(id);
            if (gerente == null)
            {
                return HttpNotFound();
            }
            return View(gerente);
        }

        // POST: Gerente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gerente gerente = db.Gerentes.Find(id);
            db.Gerentes.Remove(gerente);
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
