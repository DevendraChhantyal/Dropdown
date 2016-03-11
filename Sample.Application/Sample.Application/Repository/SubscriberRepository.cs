using Sample.Application.Context;
using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Application.Repository
{
    public interface ISubscriberRepository:IGenericRepository<Subscriber>
    {

    }
    public class SubscriberRepository : ISubscriberRepository
    {
        private AppDbConnection conn = new AppDbConnection();
        public void Insert(Subscriber t)
        {
            conn.Subscribers.Add(t);
        }

        public void Update(Subscriber t)
        {
            conn.Entry(t).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Subscriber s = GetById(id);
            conn.Subscribers.Remove(s);
        }

        public Subscriber GetById(int id)
        {
            return conn.Subscribers.Find(id);
        }

        public IEnumerable<Subscriber> GetAll()
        {
            return conn.Subscribers.ToList();
        }
    }
}