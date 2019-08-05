using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarProject.API
{
    public class ServiceTypeAPIController : ApiController
    {
        ApplicationDbContext db;
        public ServiceTypeAPIController()
        {
            db = new ApplicationDbContext();
        }
        // GET: api/ServiceTypeAPI
        public IEnumerable<ServiceType> Get()
        {
            return db.ServiceTypes.ToList();
        }
        // GET: api/ServiceTypeAPI/5
        public IHttpActionResult Get(int? id)
        {
            ServiceType serv = db.ServiceTypes.Find(id);
            if (serv == null)
            {
                return NotFound();
            }
            return Ok(serv);
        }

        // POST: api/ServiceTypeAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ServiceTypeAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ServiceTypeAPI/5
        public void Delete(int id)
        {
        }
    }
}
