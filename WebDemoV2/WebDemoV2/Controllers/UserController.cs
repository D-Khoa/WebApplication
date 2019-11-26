using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDemoV2.Models;

namespace WebDemoV2.Controllers
{
    public class UserController : Controller
    {
        private User_Entities db = new User_Entities();

        // GET: User
        public ActionResult Index()
        {
            return View(db.m_user.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            m_user m_user = db.m_user.Find(id);
            if (m_user == null)
            {
                return HttpNotFound();
            }
            return View(m_user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Passwork,Telephone,Email,Isactive,DateTimeRST")] m_user m_user)
        {
            if (ModelState.IsValid)
            {
                db.m_user.Add(m_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m_user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            m_user m_user = db.m_user.Find(id);
            if (m_user == null)
            {
                return HttpNotFound();
            }
            return View(m_user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Passwork,Telephone,Email,Isactive,DateTimeRST")] m_user m_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            m_user m_user = db.m_user.Find(id);
            if (m_user == null)
            {
                return HttpNotFound();
            }
            return View(m_user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            m_user m_user = db.m_user.Find(id);
            db.m_user.Remove(m_user);
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
