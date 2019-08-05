using CarProject.Models;
using CarProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarProject.API
{
    public class CarController : ApiController
    {
        private ApplicationDbContext db;
        public CarController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: api/User
        public IEnumerable<Car> Get()
        {
            return db.Cars.ToList();
        }
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpPost]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Cars.Add(car);
            db.SaveChanges();
            //return CreatedAtRoute("DefaultApi", new { id = car.Car.Id }, car.Car);
            return Ok(car);
            
        }

        // PUT: api/User/5
        [HttpPut]
        public IHttpActionResult UpdateUser(Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");

            var existingCar = db.Cars.Where(s=>s.Id == car.Id).FirstOrDefault<Car>();


            if (existingCar != null)
            {
                existingCar.VIN = car.VIN;
                existingCar.Make = car.Make;
                existingCar.Miles = car.Miles;
                existingCar.Model = car.Model;
                existingCar.Style = car.Style;
                existingCar.Year = car.Year;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Ok(car);
        }

        // DELETE: api/User/id
        [HttpDelete]
        public IHttpActionResult DeleteCar(int? id)
        {
            var c = db.Cars.Find(id);
            db.Cars.Remove(c);
            db.SaveChanges();
            return Ok();

        }






    }
}
