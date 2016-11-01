using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPA.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int DepartmentId { get; set; }
    }
}