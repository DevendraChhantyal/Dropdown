using Sample.Application.Models;
using Sample.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Service
{
    public interface IEmailTemplateService:IGenericService<EmailTemplate>
    {

    }
    public class EmailTemplateService : IEmailTemplateService
    {
        private EmailTemplateRepository eRepo = new EmailTemplateRepository();
        public void Insert(EmailTemplate t)
        {
            eRepo.Insert(t);
        }

        public void Delete(int id)
        {
            eRepo.Delete(id);
        }

        public void Update(EmailTemplate t)
        {
           eRepo.Update(t);
        }

        public EmailTemplate GetById(int id)
        {
           return eRepo.GetById(id);
        }

        public IEnumerable<EmailTemplate> GetAll()
        {
            return eRepo.GetAll();
        }
    }
}