using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using rpnTest.Models;

namespace rpnTest.Controllers
{
    public class ScopeOfWorkController : Controller
    {
        private rpnTestEntities db = new rpnTestEntities();

        // GET: /ScopeOfWork/
        public ActionResult Index()
        {
            return View(db.Scope_of_Work.ToList());
        }

        public ActionResult getSOW(string id)
        {
            var sowlist = from x in db.Scope_of_Work
                          join y in db.Quote_SOW on x.sow_id equals y.sow_id
                          join z in db.Quotations on y.quote_no equals z.quote_no
                          where z.quote_no == id
                              select x;
            return View(sowlist.ToList());
            //return View(db.Scope_of_Work.ToList().Where(x=>x.sow_id == id));
        }


        // GET: /ScopeOfWork/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scope_of_Work scope_of_work = db.Scope_of_Work.Find(id);
            if (scope_of_work == null)
            {
                return HttpNotFound();
            }
            return View(scope_of_work);
        }

        // GET: /ScopeOfWork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ScopeOfWork/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="sow_id,sow_desc")] Scope_of_Work scope_of_work)
        {
            if (ModelState.IsValid)
            {
                db.Scope_of_Work.Add(scope_of_work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scope_of_work);
        }

        // GET: /ScopeOfWork/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scope_of_Work scope_of_work = db.Scope_of_Work.Find(id);
            if (scope_of_work == null)
            {
                return HttpNotFound();
            }
            return View(scope_of_work);
        }

        // POST: /ScopeOfWork/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="sow_id,sow_desc")] Scope_of_Work scope_of_work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scope_of_work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scope_of_work);
        }

        // GET: /ScopeOfWork/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scope_of_Work scope_of_work = db.Scope_of_Work.Find(id);
            if (scope_of_work == null)
            {
                return HttpNotFound();
            }
            return View(scope_of_work);
        }

        // POST: /ScopeOfWork/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scope_of_Work scope_of_work = db.Scope_of_Work.Find(id);
            db.Scope_of_Work.Remove(scope_of_work);
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
