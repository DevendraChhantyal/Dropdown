using Sample.Application.Context;
using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Application.Repository
{
    public interface  IEmailTemplateRepository:IGenericRepository<EmailTemplate>
{

}
    public class EmailTemplateRepository:IEmailTemplateRepository
    {
        private AppDbConnection conn = new AppDbConnection();
        public void Insert(EmailTemplate t)
        {

            conn.EmailTemplates.Add(t);
        }

        public void Update(EmailTemplate t)
        {
            conn.Entry(t).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            EmailTemplate e = GetById(id);
            conn.EmailTemplates.Remove(e);
        }

        public EmailTemplate GetById(int id)
        {
            return conn.EmailTemplates.Find(id);
        }

        public IEnumerable<EmailTemplate> GetAll()
        {
            return conn.EmailTemplates.ToList();
        }
    }
}