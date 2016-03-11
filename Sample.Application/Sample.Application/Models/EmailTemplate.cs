using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Models
{
    public class EmailTemplate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate {get; set; }
        public bool Status { get; set; }

    }
}