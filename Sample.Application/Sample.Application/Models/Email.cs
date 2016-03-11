using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Models
{
    public class Email
    {

        public int Id { get; set; }
        public int EmailTemplateId { get; set; }
        public string Type { get; set; }
        public DateTime LogDate { get; set; }
        public EmailTemplate EmailTemplate { get; set; }
    }

    

}