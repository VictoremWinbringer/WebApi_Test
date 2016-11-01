using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi2.Models
{
    public class DbInitialazer : DropCreateDatabaseAlways<DContext>
    {
        protected override void Seed(DContext context)
        {
            context.Departments.Add(new Department { Title="Первый" });
            context.Departments.Add(new Department { Title="Второй" });
            context.Departments.Add(new Department { Title="Третий"});
            context.Departments.Add(new Department { Title= "Четвертый"});
            base.Seed(context);
        }
    }
}