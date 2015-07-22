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
    public class OrdersController : Controller
    {
        private rpnTestEntities db = new rpnTestEntities();

        // GET: /Orders/
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult GetOrdersForScope(int? id)
        {
            var ord = (from x in db.Orders
                      join y in db.Order_Item on x.order_no equals y.order_no
                      join z in db.Materials on y.mat_id equals z.mat_id
                      join a in db.Material_SOW on z.Material_SOW.FirstOrDefault().sow_id equals a.sow_id
                      where a.sow_id == id
                      orderby x.order_no
                      select x).GroupBy(x => x.order_no);
            return View(ord.ToList());
        }


//        myList.GroupBy(test => test.id)
//      .Select(grp => grp.First());

//        var result = myList.GroupBy(test => test.id)
//                   .Select(grp => grp.First())
//                   .ToList();


        public ActionResult GetOrdersForQuote(string id)
        {
            var ord = (from x in db.Orders
                      join y in db.Order_Item on x.order_no equals y.order_no
                      join z in db.Materials on y.mat_id equals z.mat_id
                      join a in db.Material_SOW on z.Material_SOW.FirstOrDefault().sow_id equals a.sow_id
                      join b in db.Quote_SOW on a.sow_id equals b.sow_id
                      where b.quote_no == id
                      select x).GroupBy(x => x.order_no).Select(grp => grp.FirstOrDefault()).ToList();
            return View(ord.ToList());
        }

        // GET: /Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: /Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="order_no,order_date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: /Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="order_no,order_date")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: /Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
