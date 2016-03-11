using Sample.Application.Models;
using Sample.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Application.Service
{
    public interface IUserService:IGenericService<User>
    {

    }
    public class UserService:IUserService
    {
        private UserRepository userRepo = new UserRepository();
        public void Insert(User t)
        {
            userRepo.Insert(t);
        }

        public void Delete(int id)
        {
            userRepo.Delete(id);
        }

        public void Update(User t)
        {
            userRepo.Update(t);
        }

        public User GetById(int id)
        {
            return userRepo.GetById(id);
               
        }

        public IEnumerable<User> GetAll()
        {
            return userRepo.GetAll();
        }
    }
}