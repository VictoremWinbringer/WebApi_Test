using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
   public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Department> Departments { get;}
        void Save();
    } 
}