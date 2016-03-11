using Sample.Application.Context;
using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Application.Repository
{
    public interface IUserRepository:IGenericRepository<User>

    {

    }
    public class UserRepository:IUserRepository
    {
        private AppDbConnection conn = new AppDbConnection();
        public void Insert(User t)
        {
            conn.Users.Add(t);
        }

        public void Update(User t)
        {
            conn.Entry(t).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            User c = GetById(id);
            conn.Users.Remove(c);
        }

        public User GetById(int id)
        {
           return conn.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return conn.Users.ToList();
        }
    }
}