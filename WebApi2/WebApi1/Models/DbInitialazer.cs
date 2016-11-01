using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi1.Models
{
    public class DbInitialazer : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(new User { UserName = "Михаил", DepartmentId = 1 });
            context.Users.Add(new User { UserName = "Виктор", DepartmentId = 2 });
            context.Users.Add(new User { UserName = "Игорь", DepartmentId = 3 });
            context.Users.Add(new User { UserName = "Моцарт", DepartmentId = 1 });
            base.Seed(context);
        }
    }
}