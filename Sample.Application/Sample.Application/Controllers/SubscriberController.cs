using Sample.Application.Context;
using Sample.Application.Models;
using Sample.Application.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sample.Application.Controllers
{
    public class SubscriberController : Controller
    { 
        private SubscriberService subscriberService;

        private AppDbConnection db = new AppDbConnection();
        public SubscriberController(SubscriberService subscriberService)
        {
            this.subscriberService = subscriberService;
        }
        // GET: Subscriber
        public ActionResult Index()
        {
            return View(subscriberService.GetAll());
        }

        // GET: Subscriber/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);

        }
        // GET: Subscriber/Create
        public ActionResult Create()
        {
            return View(new Subscriber());
        }

        // POST: Subscriber/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subscriber subscriber)
        {
            if (ModelState.IsValid)
            {
                subscriber.SubscribeDate = DateTime.Now;

                db.Subscribers.Add(subscriber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong in the database");
            return View(subscriber);
        }

        // GET: Subscriber/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Subscriber subscriber = subscriberService.GetById(id);
           
            if (subscriber == null)
            {
                return RedirectToAction("Index");
            }

            return View(subscriber);
        }

        // POST: Subscriber/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emailTemplate = db.EmailTemplates.Find(id);
            if (TryUpdateModel(emailTemplate, "",
               new string[] { "FirstName", "LastName", "Email", "SubscribeDate", "Status" }))
            {
                try
                {

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(emailTemplate);
        }




        // GET: Subscriber/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Subscriber subscriber = db.Subscribers.Find(id);
            if (subscriber == null)
            {
                return HttpNotFound();
            }
            return View(subscriber);
        }

        // POST: Subscriber/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Subscriber subscriber = db.Subscribers.Find(id);
                db.Subscribers.Remove(subscriber);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
               
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
