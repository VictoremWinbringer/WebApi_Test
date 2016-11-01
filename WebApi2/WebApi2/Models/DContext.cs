using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApi2.Models
{
    public class DContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}