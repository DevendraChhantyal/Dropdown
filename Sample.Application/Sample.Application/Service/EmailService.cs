using Sample.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Application.Repository;

namespace Sample.Application.Service
{
    public interface IEmailService : IGenericService<Email>
    {
        
    }
    public class EmailService:IEmailService
    {
        private EmailRepository emailRepo= new EmailRepository();
    public void Insert(Email t)
{
 	throw new NotImplementedException();
}

public void Delete(int id)
{
 	throw new NotImplementedException();
}

public void Update(Email t)
{
 	throw new NotImplementedException();
}

public Email GetById(int id)
{
 	throw new NotImplementedException();
}

public IEnumerable<Email> GetAll()
{
    return emailRepo.GetAll();
}
}
}