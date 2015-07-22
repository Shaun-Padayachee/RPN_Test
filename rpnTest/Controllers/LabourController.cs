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
    public class LabourController : Controller
    {
        private rpnTestEntities db = new rpnTestEntities();

        // GET: /Labour/
        public ActionResult Index()
        {
            var labour_sow = db.Labour_SOW.Include(l => l.Labour).Include(l => l.Scope_of_Work);
            return View(labour_sow.ToList());
        }

        public ActionResult GetLabour(int? id)
        {
            var lab = from x in db.Labours
                      join y in db.Labour_SOW on x.lab_id equals y.lab_id
                      join z in db.Scope_of_Work on y.sow_id equals z.sow_id
                      where z.sow_id == id
                      select x;

            return View(lab.ToList());
            //var labour_sow = db.Labour_SOW.Include(l => l.Labour).Include(l => l.Scope_of_Work);
            //return View(labour_sow.ToList());
        }

        // GET: /Labour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labour_SOW labour_sow = db.Labour_SOW.Find(id);
            if (labour_sow == null)
            {
                return HttpNotFound();
            }
            return View(labour_sow);
        }

        // GET: /Labour/Create
        public ActionResult Create()
        {
            ViewBag.lab_id = new SelectList(db.Labours, "lab_id", "lab_desc");
            ViewBag.sow_id = new SelectList(db.Scope_of_Work, "sow_id", "sow_desc");
            return View();
        }

        // POST: /Labour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="lab_sow_id,sow_id,lab_id,lab_hrs")] Labour_SOW labour_sow)
        {
            if (ModelState.IsValid)
            {
                db.Labour_SOW.Add(labour_sow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lab_id = new SelectList(db.Labours, "lab_id", "lab_desc", labour_sow.lab_id);
            ViewBag.sow_id = new SelectList(db.Scope_of_Work, "sow_id", "sow_desc", labour_sow.sow_id);
            return View(labour_sow);
        }

        // GET: /Labour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labour_SOW labour_sow = db.Labour_SOW.Find(id);
            if (labour_sow == null)
            {
                return HttpNotFound();
            }
            ViewBag.lab_id = new SelectList(db.Labours, "lab_id", "lab_desc", labour_sow.lab_id);
            ViewBag.sow_id = new SelectList(db.Scope_of_Work, "sow_id", "sow_desc", labour_sow.sow_id);
            return View(labour_sow);
        }

        // POST: /Labour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="lab_sow_id,sow_id,lab_id,lab_hrs")] Labour_SOW labour_sow)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labour_sow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lab_id = new SelectList(db.Labours, "lab_id", "lab_desc", labour_sow.lab_id);
            ViewBag.sow_id = new SelectList(db.Scope_of_Work, "sow_id", "sow_desc", labour_sow.sow_id);
            return View(labour_sow);
        }

        // GET: /Labour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labour_SOW labour_sow = db.Labour_SOW.Find(id);
            if (labour_sow == null)
            {
                return HttpNotFound();
            }
            return View(labour_sow);
        }

        // POST: /Labour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labour_SOW labour_sow = db.Labour_SOW.Find(id);
            db.Labour_SOW.Remove(labour_sow);
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
