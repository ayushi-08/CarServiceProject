using CarProject.Models;
using CarProject.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext _context;
        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        //GET:Car
        public ActionResult ViewCars(string id)
        {
            IEnumerable<Car> car;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Car").Result;
            car = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;

            //var id = HttpContext.User.Identity.GetUserId();
       
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("User/"+id).Result;
            var user = response1.Content.ReadAsAsync<ApplicationUser>().Result;

            var viewModel = new CarAndCustomerViewModel()
            {
                User=user,
                Cars=car
            };
            return View(viewModel);

        }

        public ActionResult Create(ApplicationUser user)
        {
            var viewModel = new CarAndCustomerViewModel
            {
                User = user
            };
             return View(viewModel);
        }

        //POST:Create Car
        [HttpPost]
        public ActionResult Create(CarAndCustomerViewModel cc)
        {
            cc.Car.UserId = cc.User.Id;
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Car", cc.Car).Result;
            //TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("ViewCars","Car",new {cc.User.Id });
        }
        //public ActionResult NewCar(CarAndCustomerViewModel cc)
        //{
        //    cc.Car.UserId = cc.User.Id;
        //    _context.
        //    car_context.SaveChanges();
        //    cc.Customerr = car_context.Customers.Find(cc.Customerr.Id);
        //    return RedirectToAction("ViewCars", "Car", cc.Customerr);
        //}

        // GET: Users/Edit/
        public ActionResult Edit(Car car)
        {
            return View(car);
        }

        
        public ActionResult Update(Car car)
        {
            var id = car.UserId;
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.PutAsJsonAsync("Car", car).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("ViewCars", "Car", new { id});
           
        }

        public ActionResult Delete(Car car)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Car/" + car.Id).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("ViewCars","Car", new { car.UserId });
        }
    }
}