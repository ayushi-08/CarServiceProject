using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarProject.API
{
    public class ServiceAPIController : ApiController
    {
        private ApplicationDbContext db;
        public ServiceAPIController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: api/ServiceAPI
        public IEnumerable<Service> Get()
        {
            return db.Services.ToList();
        }
        // GET: api/ServiceAPI/id
        public IHttpActionResult GetService(int id)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        //Create Service
        [HttpPost]
        public IHttpActionResult PostService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Services.Add(service);
            db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = service.CarId}, service);
            return Ok(service);
        }
        // DELETE: api/User/id
        [HttpDelete]
        public IHttpActionResult DeleteService(int? id)
        {
            var c = db.Services.Find(id);
            db.Services.Remove(c);
            db.SaveChanges();
            return Ok(c);

        }

    }

}

