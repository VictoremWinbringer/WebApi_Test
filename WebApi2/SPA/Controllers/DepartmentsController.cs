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
        private IUnitOfWork db = new UnitOfWork();

        /// <summary>
        /// Получает списко департаментов
        /// </summary>
        /// <returns> Список департаметнов </returns>
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await db.Departments.GetAll();
        }

        /// <summary>
        /// Возврашает департамент в формате JSON
        /// </summary>
        /// <param name="id">id департамента в БД</param>
        /// <returns>Департамент</returns>
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