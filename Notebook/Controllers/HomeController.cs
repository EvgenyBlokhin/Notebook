using Notebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Notebook.Controllers {
    public class HomeController : Controller {
        NotebookContext db = new NotebookContext();

        public ActionResult Index() {
                var contacts = db.Contacts.Include(c => c.Category);
                return View(contacts);
        }

        [HttpGet]
        public ActionResult Create() {
                SelectList categories = new SelectList(db.Categories, "Id", "Name");
                ViewBag.Categories = categories;
                return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact) {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contact contact = db.Contacts.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
                if (contact != null)
                {
                    SelectList categories = new SelectList(db.Categories, "Id", "Name");
                    ViewBag.Categories = categories;
                    return View(contact);
                }
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Contact contact) {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            Contact contact = db.Contacts.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id) {
            if (id == null)
            {
                return HttpNotFound();
            }
            Contact contact = db.Contacts.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            if (contact != null)
                {
                    db.Contacts.Remove(contact);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
        }

        public ActionResult Details(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}