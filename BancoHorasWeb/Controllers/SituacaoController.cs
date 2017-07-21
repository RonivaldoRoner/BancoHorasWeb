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
    public class SituacaoController : Controller
    {
        private BancoHorasWebContext db = new BancoHorasWebContext();

        // GET: Situacao
        public ActionResult Index()
        {
            return View(db.Situacaos.ToList());
        }

        // GET: Situacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacaos.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // GET: Situacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Situacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SituacaoId,Nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Situacaos.Add(situacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situacao);
        }

        // GET: Situacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacaos.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SituacaoId,Nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situacao);
        }

        // GET: Situacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.Situacaos.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Situacao situacao = db.Situacaos.Find(id);
            db.Situacaos.Remove(situacao);
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
