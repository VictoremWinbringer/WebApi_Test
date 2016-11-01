using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
    public class UnitOfWork : IUnitOfWork
    {
     Lazy<DepartmentRepository> dr = new Lazy<DepartmentRepository>();
        Lazy<UserRepository> ur = new Lazy<UserRepository>();
        public DepartmentRepository Departments
        {
            get
            {
                return dr.Value;
            }
        }

        public UserRepository Users
        {
            get
            {
                return ur.Value;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}