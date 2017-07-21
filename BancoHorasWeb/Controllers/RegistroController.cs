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
    public class RegistroController : Controller
    {
        private BancoHorasWebContext db = new BancoHorasWebContext();

        // GET: Registro
        public ActionResult Index()
        {
            var registroes = db.Registroes.Include(r => r.Funcionario).Include(r => r.Gerente);
            return View(registroes.ToList());
        }

        // GET: Registro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF");
            ViewBag.GerenteId = new SelectList(db.Gerentes, "GerenteId", "GerenteId");
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistroId,FuncionarioId,DataRegistro,InicioReg,FimReg,SaldoDias,SaldoHoras,GerenteId,Descricao")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registroes.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", registro.FuncionarioId);
            ViewBag.GerenteId = new SelectList(db.Gerentes, "GerenteId", "GerenteId", registro.GerenteId);
            return View(registro);
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", registro.FuncionarioId);
            ViewBag.GerenteId = new SelectList(db.Gerentes, "GerenteId", "GerenteId", registro.GerenteId);
            return View(registro);
        }

        // POST: Registro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistroId,FuncionarioId,DataRegistro,InicioReg,FimReg,SaldoDias,SaldoHoras,GerenteId,Descricao")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FuncionarioId = new SelectList(db.Funcionarios, "FuncionarioId", "CPF", registro.FuncionarioId);
            ViewBag.GerenteId = new SelectList(db.Gerentes, "GerenteId", "GerenteId", registro.GerenteId);
            return View(registro);
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registroes.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registroes.Find(id);
            db.Registroes.Remove(registro);
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
