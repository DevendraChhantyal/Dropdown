namespace Sample.Application.Migrations
{
    using Sample.Application.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sample.Application.Context.AppDbConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sample.Application.Context.AppDbConnection context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<User> uList = new List<User>(){
                new User(){
                    FirstName="ram",LastName="bhatta",Email="ram@gmail.com",AddedDate=DateTime.Now,ModifiedDate=null,Status=true
                },
                
                 new User(){
                    FirstName="hari",LastName="baral",Email="hari@gmail.com",AddedDate=DateTime.Now,ModifiedDate=null,Status=true
                },
                 new User(){
                    FirstName="bikash",LastName="thapa",Email="bikash@gmail.com",AddedDate=DateTime.Now,ModifiedDate=null,Status=false
                }

            };
            uList.ForEach(u=>
            {
            context.Users.Add(u);
                context.SaveChanges();


        });


            List<EmailTemplate> eList = new List<EmailTemplate>()
            {
              new EmailTemplate()
              {
                  Title="Holiday",
                  Content="Christmas",
                  AddedDate=DateTime.Now,
                  ModifiedDate=null,
                  Status=true
              },
               new EmailTemplate()
              {
                  Title="Reminder",
                  Content="Business Meeting",
                  AddedDate=DateTime.Now,
                  ModifiedDate=null,
                  Status=true
              },
               new EmailTemplate()
              {
                  Title="Public Holiday",
                  Content="Democracy Day",
                  AddedDate=DateTime.Now,
                  ModifiedDate=null,
                  Status=true
              },
               new EmailTemplate()
              {
                  Title="Seminar",
                  Content="There has been a seismic shift in media that has changed consumer consumption habits. When it comes to holiday marketing, marketers should be aware of offering audiences content earlier on in the year, said Avi Zimak, Outbrain North America general manager. ",
                  AddedDate=DateTime.Now,
                  ModifiedDate=null,
                  Status=true
              },
               new EmailTemplate()
              {
                  Title="Half Day",
                  Content="There has been a seismic shift in media that has changed consumer consumption habits. When it comes to holiday marketing, marketers should be aware of offering audiences content earlier on in the year, said Avi Zimak, Outbrain North America general manager.",
                  AddedDate=DateTime.Now,
                  ModifiedDate=null,
                  Status=true
              }
            };
            eList.ForEach(e =>
            {
                context.EmailTemplates.Add(e);
                context.SaveChanges();
            });

            List<Email> emList = new List<Email>()
            {
                new Email(){
                    EmailTemplateId= eList.Single(p=>p.Title=="Holiday").Id,
                    LogDate=DateTime.Now,
                    Type="User"
                },
                new Email(){
                    EmailTemplateId= eList.Single(p=>p.Title=="Half Day").Id,
                    LogDate=DateTime.Now,
                    Type="Subscriber"
                }


            };
            emList.ForEach(em =>
                {
                    context.Emails.Add(em);
                    context.SaveChanges();

                });
            List<Subscriber> sList = new List<Subscriber>()
            {

                new Subscriber()
                {
                    FirstName="Radhe",
                    LastName="Shyam",
                    Email="radhe@gmail.com",
                    SubscribeDate=DateTime.Now,
                    Status=true
                    },

                    
                new Subscriber()
                {
                    FirstName="Gopal",
                    LastName="Tuladhar",
                    Email="gopal@gmail.com",
                    SubscribeDate=DateTime.Now,
                    Status=true
                  },
                  new Subscriber()
                {
                    FirstName="Mukesh",
                    LastName="Tulachan",
                    Email="mukesh@gmail.com",
                    SubscribeDate=DateTime.Now,
                    Status=false
                  }
            };
            sList.ForEach(s =>
                {
                    context.Subscribers.Add(s);
                    context.SaveChanges();
                });
             
            
        }
    }
}
