using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarProject.API
{
    public class UserController : ApiController
    {
        private ApplicationDbContext db;
        public UserController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: api/User
        public IEnumerable<ApplicationUser> Get()
        {
             return db.Users.ToList();          
        }

        //Get User By Id
        public IHttpActionResult GetUser(string id)
        {
            ApplicationUser user = db.Users.Where(c=>c.Id.Equals(id)).SingleOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
       
        // POST: api/User
        public IHttpActionResult PostUser(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Users.Add(user);
            db.SaveChanges();      
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut]
        public IHttpActionResult UpdateUser(ApplicationUser user)
        {
            if (!ModelState.IsValid)
               return BadRequest("Not a valid data");
            var existingUser = db.Users.Where(s => s.Email == user.Email).FirstOrDefault<ApplicationUser>();

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/User/id
        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {
            var u = db.Users.Find(id);
            db.Users.Remove(u);
            db.SaveChanges();
            return Ok(u);
           
        }
    }
}
