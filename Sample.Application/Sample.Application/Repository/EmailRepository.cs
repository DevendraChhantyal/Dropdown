using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Application.Context;
using Sample.Application.Models;

namespace Sample.Application.Repository
{
    public interface IEmailRepository : IGenericRepository<Email>
    {
        
    }
    public class EmailRepository:IEmailRepository
    {
        private  AppDbConnection conn = new AppDbConnection();
        public void Insert(Email t)
        {
            throw new NotImplementedException();
        }

        public void Update(Email t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Email GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Email> GetAll()
        {
            return conn.Emails.ToList();
        }
    }
}