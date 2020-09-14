using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admTarea1.Models;

namespace admTarea1.Controllers
{
    public class jimenezsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: jimenezs
        [Authorize]
        public ActionResult Index()
        {
            return View(db.jimenezs.ToList());
        }

        // GET: jimenezs/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jimenez jimenez = db.jimenezs.Find(id);
            if (jimenez == null)
            {
                return HttpNotFound();
            }
            return View(jimenez);
        }

        // GET: jimenezs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: jimenezs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JimenezID,FriendofJimenez,Email,Birthday,Place")] jimenez jimenez)
        {
            if (ModelState.IsValid)
            {
                db.jimenezs.Add(jimenez);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jimenez);
        }

        // GET: jimenezs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jimenez jimenez = db.jimenezs.Find(id);
            if (jimenez == null)
            {
                return HttpNotFound();
            }
            return View(jimenez);
        }

        // POST: jimenezs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JimenezID,FriendofJimenez,Email,Birthday,Place")] jimenez jimenez)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jimenez).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jimenez);
        }

        // GET: jimenezs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jimenez jimenez = db.jimenezs.Find(id);
            if (jimenez == null)
            {
                return HttpNotFound();
            }
            return View(jimenez);
        }

        // POST: jimenezs/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jimenez jimenez = db.jimenezs.Find(id);
            db.jimenezs.Remove(jimenez);
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
