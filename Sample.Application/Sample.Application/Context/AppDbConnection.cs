using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Application.Context
{
    public class AppDbConnection:DbContext
    {
        public AppDbConnection()
            :base("DefaultConnection")
        {

        }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}