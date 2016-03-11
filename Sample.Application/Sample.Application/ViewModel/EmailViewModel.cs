using Sample.Application.Context;
using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Sample.Application.ViewModel
{
    public class EmailViewModel
    {

        private AppDbConnection db = new AppDbConnection();
        public IEnumerable<SelectListItem> Title { get; set; }
        public Email Email { get; set; }


        public EmailViewModel(Email email)
        {
            Email = email;
            Title = PopulateTitle();
        }
        private IEnumerable<SelectListItem> PopulateTitle()
        {
            var titleQuery = db.EmailTemplates.OrderBy(t => t.Id);
            return new SelectList(titleQuery, "Title", "Id");
        }
    }
}