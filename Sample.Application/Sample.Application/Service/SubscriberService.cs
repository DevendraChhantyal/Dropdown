using Sample.Application.Models;
using Sample.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Service
{
    public interface ISubscriberService:IGenericService<Subscriber>
    {

    }
    public class SubscriberService : ISubscriberService
    {
        private SubscriberRepository subscriberRepo = new SubscriberRepository();
        public void Insert(Subscriber t)
        {
            subscriberRepo.Insert(t);
        }

        public void Delete(int id)
        {
            subscriberRepo.Delete(id);
        }

        public void Update(Subscriber t)
        {
            subscriberRepo.Update(t);
        }

        public Subscriber GetById(int id)
        {
            return subscriberRepo.GetById(id);
        }

        public IEnumerable<Subscriber> GetAll()
        {
            return subscriberRepo.GetAll();
        }
    }
}