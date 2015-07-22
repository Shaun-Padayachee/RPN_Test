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
    public class ClientAddressController : Controller
    {
        private rpnTestEntities db = new rpnTestEntities();

        // GET: /ClientAddress/
        public ActionResult Index()
        {
            var client_address = db.Client_Address.Include(c => c.Address).Include(c => c.Client);
            return View(client_address.ToList());
        }

        // GET: /ClientAddress/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Address client_address = db.Client_Address.Where(x => x.client_id == id).FirstOrDefault();
            if (client_address == null)
            {
                return HttpNotFound();
            }
            return View(client_address);
        }

        // GET: /ClientAddress/Create
        public ActionResult Create()
        {
            ViewBag.adr_id = new SelectList(db.Addresses, "adr_id", "adr_line_1");
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "client_name");
            return View();
        }

        // POST: /ClientAddress/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="cli_adr_id,adr_id,client_id")] Client_Address client_address)
        {
            if (ModelState.IsValid)
            {
                db.Client_Address.Add(client_address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adr_id = new SelectList(db.Addresses, "adr_id", "adr_line_1", client_address.adr_id);
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "client_name", client_address.client_id);
            return View(client_address);
        }

        // GET: /ClientAddress/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Address client_address = db.Client_Address.Find(id);
            if (client_address == null)
            {
                return HttpNotFound();
            }
            ViewBag.adr_id = new SelectList(db.Addresses, "adr_id", "adr_line_1", client_address.adr_id);
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "client_name", client_address.client_id);
            return View(client_address);
        }

        // POST: /ClientAddress/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="cli_adr_id,adr_id,client_id")] Client_Address client_address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adr_id = new SelectList(db.Addresses, "adr_id", "adr_line_1", client_address.adr_id);
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "client_name", client_address.client_id);
            return View(client_address);
        }

        // GET: /ClientAddress/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Address client_address = db.Client_Address.Find(id);
            if (client_address == null)
            {
                return HttpNotFound();
            }
            return View(client_address);
        }

        // POST: /ClientAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_Address client_address = db.Client_Address.Find(id);
            db.Client_Address.Remove(client_address);
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
