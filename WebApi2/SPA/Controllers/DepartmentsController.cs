using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SPA.Models
{
    public class DepartmentsController : ApiController
    {
        private UnitOfWork db = new UnitOfWork();

        // GET: api/Departments
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await db.Departments.GetAll();
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Department))]
        public async Task<IHttpActionResult> GetDepartment(int id)
        {
            Department department = await db.Departments.Get(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }
    }
}