using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicCRUD.Models;

namespace BasicCRUD.Controllers
{
    public class ManageUserController : Controller
    {
        private WebApiDBEntities db = new WebApiDBEntities();

        //
        // GET: /ManageUser/

        public ActionResult Index()
        {
            return View(db.userinfoes.ToList());
        }

        //
        // GET: /ManageUser/Details/5

        public ActionResult Details(int id = 0)
        {
            userinfo userinfo = db.userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // GET: /ManageUser/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManageUser/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.userinfoes.Add(userinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userinfo);
        }

        //
        // GET: /ManageUser/Edit/5

        public ActionResult Edit(int id = 0)
        {
            userinfo userinfo = db.userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /ManageUser/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        //
        // GET: /ManageUser/Delete/5

        public ActionResult Delete(int id = 0)
        {
            userinfo userinfo = db.userinfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        //
        // POST: /ManageUser/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userinfo userinfo = db.userinfoes.Find(id);
            db.userinfoes.Remove(userinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}