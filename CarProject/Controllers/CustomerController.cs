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
    public class CustomerController : Controller
    {
        ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult ViewCars(ApplicationUser user)
        {
            //// var car = car_context.Cars.ToList();
            //var viewModel = new CarAndCustomerViewModel
            //{
            //    User = user,
            //    Cars = db.Cars.ToList()
            //};
            //return View(viewModel);
            IEnumerable<Car> car;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Car").Result;
            car = response.Content.ReadAsAsync<IEnumerable<Car>>().Result;

            var id = HttpContext.User.Identity.GetUserId();

            HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("User/" + id.ToString()).Result;
             user = response1.Content.ReadAsAsync<ApplicationUser>().Result;

            var viewModel = new CarAndCustomerViewModel()
            {
                User = user,
                Cars = car
            };
            return View(viewModel);

        }
    }
}
