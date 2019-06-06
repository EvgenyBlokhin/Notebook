﻿using Notebook.Models;
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
            //using (NotebookContext db = new NotebookContext())
            //{
                var contacts = db.Contacts.Include(c => c.Category);
                return View(contacts);
            //}
        }

        [HttpGet]
        public ActionResult Create() {
            //using (NotebookContext db = new NotebookContext())
            //{
                SelectList categories = new SelectList(db.Categories, "Id", "Name");
                ViewBag.Categories = categories;
                return View();
            //}
        }

        [HttpPost]
        public ActionResult Create(Contact contact) {
            //using (NotebookContext db = new NotebookContext())
            //{
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return HttpNotFound();
            }
            //using (NotebookContext db = new NotebookContext())
            //{
                Contact contact = db.Contacts.Include(c => c.Category).ToList().Where(p => p.Id == id).First();
                if (contact != null)
                {
                    SelectList categories = new SelectList(db.Categories, "Id", "Name");
                    ViewBag.Categories = categories;
                    return View(contact);
                }
                return RedirectToAction("Index");
            //}
        }

        [HttpPost]
        public ActionResult Edit(Contact contact) {
            //using (NotebookContext db = new NotebookContext())
            //{
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
        }

        [HttpGet]
        public ActionResult Delete(int id) {
            //using (NotebookContext db = new NotebookContext())
            //{
                Contact contact = db.Contacts.Include(c => c.Category).ToList().Where(p => p.Id == id).First();
                if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
            //}
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id) {
            if (id == null)
            {
                return HttpNotFound();
            }
            //using (NotebookContext db = new NotebookContext())
            //{
                Contact contact = db.Contacts.Include(c => c.Category).ToList().Where(p => p.Id == id).First();
                if (contact != null)
                {
                    db.Contacts.Remove(contact);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            //}
        }

        public ActionResult Details(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //using (NotebookContext db = new NotebookContext())
            //{
                Contact contact = db.Contacts.Include(c => c.Category).ToList().Where(p => p.Id == id).First();
                if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
            //}
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