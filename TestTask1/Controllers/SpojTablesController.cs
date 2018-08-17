using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTask1.Models;

namespace TestTask1.Controllers
{
    public class SpojTablesController : Controller
    {
        private AgriviDBEntities db = new AgriviDBEntities();

        // GET: SpojTables
        public ActionResult Index()
        {
            return View(db.SpojTable.ToList());
        }

        // GET: SpojTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpojTable spojTable = db.SpojTable.Find(id);
            if (spojTable == null)
            {
                return HttpNotFound();
            }
            return View(spojTable);
        }

        // GET: SpojTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpojTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Tip,Vodik,Dusik,Ugljik,Natrij,Kisik")] SpojTable spojTable)
        {
            if (ModelState.IsValid)
            {
                if (CheckElements(spojTable))
                {
                    db.SpojTable.Add(spojTable);
                    db.SaveChanges();
                    spojTable.Error = "";
                    return RedirectToAction("Index");
                }
                else
                {
                    spojTable.Error = "Min broj elemenata = 2";
                }
            
            }

            return View(spojTable);
        }

        // GET: SpojTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpojTable spojTable = db.SpojTable.Find(id);
            if (spojTable == null)
            {
                return HttpNotFound();
            }
            return View(spojTable);
        }

        // POST: SpojTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Tip,Vodik,Dusik,Ugljik,Natrij,Kisik")] SpojTable spojTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spojTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spojTable);
        }

        // GET: SpojTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpojTable spojTable = db.SpojTable.Find(id);
            if (spojTable == null)
            {
                return HttpNotFound();
            }
            return View(spojTable);
        }

        // POST: SpojTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpojTable spojTable = db.SpojTable.Find(id);
            db.SpojTable.Remove(spojTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool CheckElements(SpojTable kemSpoj)
        {
            int noVodik = kemSpoj.Vodik.HasValue ? 1 : 0;
            int noDusik = kemSpoj.Dusik.HasValue ? 1 : 0;
            int noUgljik = kemSpoj.Ugljik.HasValue ? 1 : 0;
            int noNatrij = kemSpoj.Natrij.HasValue ? 1 : 0;
            int noKisik = kemSpoj.Kisik.HasValue ? 1 : 0;
            int noElems = noVodik + noDusik + noUgljik + noNatrij + noKisik;
            if (noElems >= 2) return true;
            return false;
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
