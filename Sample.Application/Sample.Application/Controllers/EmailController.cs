using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sample.Application.Context;
using Sample.Application.Service;
using Sample.Application.ViewModel;
using Sample.Application.Models;

namespace Sample.Application.Controllers
{
    public class EmailController : Controller
    {
         private EmailService emailService;

        private AppDbConnection db = new AppDbConnection();
        public EmailController(EmailService emailService)
        {
          
            this.emailService = emailService;
        }
        // GET: Email
        public ActionResult Index()
        {
            //ViewBag.Emails = new SelectList(db.Emails, "Id", "EmailTemplateId");
            var emailViewModel = new EmailViewModel(new Email());
            return View(emailService.GetAll());
        }

        // GET: Email/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Email/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Email/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Email/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Email/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Email/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
