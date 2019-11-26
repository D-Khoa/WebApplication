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
    public class UserLoginController : Controller
    {
        private DBLoginEntities db = new DBLoginEntities();

        // GET: UserLogin
        public ActionResult Index()
        {
            return View(db.m_user.ToList());
        }

        // GET: UserLogin/Details/5
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

        // GET: UserLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Telephone,Email,Isactive,DateTimeRST")] m_user m_user)
        {
            if (ModelState.IsValid)
            {
                db.m_user.Add(m_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(m_user);
        }

        // GET: UserLogin/Edit/5
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

        // POST: UserLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Password,Telephone,Email,Isactive,DateTimeRST")] m_user m_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m_user);
        }

        // GET: UserLogin/Delete/5
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

        // POST: UserLogin/Delete/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "UserName,Telephone,Email,Password,DateTimeRST")] m_user objuser)
        {
            if (ModelState.IsValid)
            {
                objuser.Isactive = true;
                objuser.DateTimeRST = DateTime.Now;
                db.m_user.Add(objuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objuser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn([Bind(Include = "Email,Password")] m_user objuser)
        {
            if (ModelState.IsValid)
            {
                var obj = db.m_user.Where(a => a.Email.Equals(objuser.Email) && a.Password.Equals(objuser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["ID"] = obj.ID.ToString();
                    Session["UserName"] = obj.UserName.ToString();
                    return RedirectToAction("Index");
                }
                else
                    return Content("Wrong Email or Password!!");
            }
            return View(objuser);
        }
    }
}
