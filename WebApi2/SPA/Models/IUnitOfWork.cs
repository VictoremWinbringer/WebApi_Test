using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
    interface IUnitOfWork:IDisposable
    {
        UserRepository Users { get; }
        DepartmentRepository Departments { get;}
        void Save();
    } 
}