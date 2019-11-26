using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoWeb.Models;

namespace DemoWeb.Controllers
{
    public class LinkController : Controller
    {
        private StepDB db = new StepDB();

        // GET: Link
        public ActionResult Index()
        {
            return View(db.ProcessSteps.ToList());
        }

        // GET: Link/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessStep processStep = db.ProcessSteps.Find(id);
            if (processStep == null)
            {
                return HttpNotFound();
            }
            return View(processStep);
        }

        // GET: Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StepID,StepName,Description,IsActive,LastUpdate,LastUpdateBy")] ProcessStep processStep)
        {
            if (ModelState.IsValid)
            {
                db.ProcessSteps.Add(processStep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processStep);
        }

        // GET: Link/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessStep processStep = db.ProcessSteps.Find(id);
            if (processStep == null)
            {
                return HttpNotFound();
            }
            return View(processStep);
        }

        // POST: Link/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StepID,StepName,Description,IsActive,LastUpdate,LastUpdateBy")] ProcessStep processStep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processStep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processStep);
        }

        // GET: Link/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcessStep processStep = db.ProcessSteps.Find(id);
            if (processStep == null)
            {
                return HttpNotFound();
            }
            return View(processStep);
        }

        // POST: Link/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcessStep processStep = db.ProcessSteps.Find(id);
            db.ProcessSteps.Remove(processStep);
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
