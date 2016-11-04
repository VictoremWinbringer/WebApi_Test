using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SPA.Models;
using System.Web;
using System.Threading.Tasks;
using AutoMapper;

namespace SPA.Controllers
{
    public class UsersController : ApiController
    {
        private IUnitOfWork db = new UnitOfWork();


        public UsersController()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>()
.ForMember("Department",opt=> opt.Ignore());

                cfg.CreateMap<UserViewModel, User>();
            }); 
        }
        // GET: api/Users
        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var u =await db.Users.GetAll();
            var d = await db.Departments.GetAll();
            var u1 = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(u);
            foreach (var item in u1)
            {
                item.Department = d.FirstOrDefault(x => x.Id == item.DepartmentId)?.Title;
            }
            return u1; 
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserViewModel))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            var d =await db.Departments.Get(user.DepartmentId);
            var u = Mapper.Map<UserViewModel>(user);
            u.Department = d?.Title;
            return Ok(u);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(UserViewModel))]
        [HttpPut]
        public async Task<IHttpActionResult> PutUser(int id, UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }


            try
            {
                await db.Users.Update(Mapper.Map<User>(user));
                var d = await db.Departments.Get(user.DepartmentId);
                user.Department = d?.Title;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(user);
        }

        // POST: api/Users
      //  [ResponseType(typeof(User))]
        [HttpPost]
        public async Task<IHttpActionResult> PostUser(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserViewModel uv;
            try
            {
              var u = await db.Users.Create(Mapper.Map<User>(user));
              var d = await db.Departments.Get(user.DepartmentId);
                uv = Mapper.Map<UserViewModel>(u);
                uv.Department = d?.Title;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        
            return CreatedAtRoute("DefaultApi", new { id = uv?.Id }, uv); //Ok(user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserViewModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.Get(id);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                await db.Users.Delete(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(Mapper.Map<UserViewModel>(user));
        }


    }
}