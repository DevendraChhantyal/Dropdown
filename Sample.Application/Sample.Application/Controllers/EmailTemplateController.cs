﻿using Sample.Application.Context;
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
    public class EmailTemplateController : Controller
    {
        private EmailTemplateService emailTemplateService;
        private AppDbConnection db = new AppDbConnection();
        public EmailTemplateController(EmailTemplateService emailTemplateService)
        {
            this.emailTemplateService = emailTemplateService;
        }

        // GET: EmailTemplate
        public ActionResult Index()
        {
            return View(emailTemplateService.GetAll());
        }

        // GET: EmailTemplate/Details/5
        public ActionResult Details(int? id)
        {
           if(id==null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if(emailTemplate==null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        // GET: EmailTemplate/Create
        public ActionResult Create()
        {
            return View(new EmailTemplate());
        }

        // POST: EmailTemplate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmailTemplate emailTemplate)
        {
            if (ModelState.IsValid)
            {
                emailTemplate.AddedDate = DateTime.Now;

                db.EmailTemplates.Add(emailTemplate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong in the database");
            return View(emailTemplate);
        }

        // GET: EmailTemplate/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            EmailTemplate emailTemplate = emailTemplateService.GetById(id);

            if (emailTemplate == null)
            {
                return RedirectToAction("Index");
            }

            return View(emailTemplate);
        }

        // POST: EmailTemplate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emailTemplate = db.EmailTemplates.Find(id);
            if (TryUpdateModel(emailTemplate, "",
               new string[] { "Title", "Content", "AddedDate", "ModifiedDate", "Status" }))
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

        // GET: EmailTemplate/Delete/5
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
            EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
            if (emailTemplate == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplate);
        }

        // POST: EmailTemplate/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                EmailTemplate emailTemplate = db.EmailTemplates.Find(id);
                db.EmailTemplates.Remove(emailTemplate);
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
