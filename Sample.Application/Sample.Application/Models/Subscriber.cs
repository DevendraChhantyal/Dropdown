using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime SubscribeDate { get; set; }
        public bool Status { get; set; }

    }
}