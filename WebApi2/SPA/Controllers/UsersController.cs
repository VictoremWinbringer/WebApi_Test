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

namespace SPA.Controllers
{
    public class UsersController : ApiController
    {
        private IUnitOfWork db = new UnitOfWork();

        // GET: api/Users
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.GetAll();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(User))]
        [HttpPut]
        public async Task<IHttpActionResult> PutUser(int id, User user)
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
                await db.Users.Update(user);
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
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User u;
            try
            {
               u = await db.Users.Create(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return CreatedAtRoute("DefaultApi", new { id = u.Id }, u); //Ok(user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
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
            return Ok(user);
        }


    }
}