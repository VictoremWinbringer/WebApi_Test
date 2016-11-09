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
        public IRepository<Department> Departments
        {
            get
            {
                return dr.Value;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return ur.Value;
            }
        }

        public void Dispose()
        {
        }

        public void Save()
        {
        }
    }
}