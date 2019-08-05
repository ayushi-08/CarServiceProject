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
    public class ServiceController : Controller
    {
        ApplicationDbContext service_cont;
        public ServiceController()
        {
            service_cont = new ApplicationDbContext();
        }
        // GET: Service
        public ActionResult ServiceForm(Car car)
        {
            var viewModel = new CarServiceViewModel
            {
                Cars = car,
            };
            return View(viewModel);
        }
        public ActionResult ViewService(Car car)
        {
            var serv = service_cont.Services.ToList();
            var servType = service_cont.ServiceTypes.ToList();
            List<Service> listofservice = new List<Service>();
            //if (serv.Count < 5)
            //{
            foreach (var item in serv)
            {
                if (item.CarId == car.Id)
                    listofservice.Add(item);
            }
            //}
            var viewModel = new CarServiceViewModel
            {
                Cars = car,
                PastServices = listofservice,
                serviceTypes = servType
            };
            //var viewModel = new CarServiceEnumerableViewModel
            //{
            //    //carId = car.Id,
            //    Cars = car,
            //    Services = service
            //};
            return View(viewModel);
        }
        public ActionResult NewService(CarServiceViewModel cs)
        {
            cs.Services.CarId = cs.Cars.Id;
            cs.Services.DateAdded = DateTime.Today.Date;
            service_cont.Services.Add(cs.Services);
            service_cont.SaveChanges();
            var car = service_cont.Cars.Find(cs.Cars.Id);

            return RedirectToAction("ViewService", "Service", car);
        }
        public ActionResult DeleteService(int? id)
        {
            var service = service_cont.Services.Find(id);
            var car = service_cont.Cars.Find(service.CarId);
            service_cont.Services.Remove(service);
            service_cont.SaveChanges();
            return RedirectToAction("ViewService", "Service", car);
        }

    }
}











        //    public ActionResult ServiceForm(Car car)
        //    {
        //        var viewModel = new CarServiceViewModel
        //        {
        //            Cars = car,
        //        };
        //        return View(viewModel);
        //    }
        //    public ActionResult ViewService(Car car)
        //    {
        //        IEnumerable<Service> service;
        //        HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ServiceAPI").Result;
        //        service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;

        //        //IEnumerable<ServiceType> serviceType;
        //        //HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("ServiceTypeAPI").Result;
        //        //serviceType = response.Content.ReadAsAsync<IEnumerable<ServiceType>>().Result;

        //       // var id = HttpContext.User.Identity.GetUserId();
        //        HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("Car/" + id.ToString()).Result;
        //        car = response2.Content.ReadAsAsync<Car>().Result;

        //        List<Service> listofservice = new List<Service>();
        //        foreach (var item in service)
        //        {
        //            if (item.CarId == car.Id)
        //                listofservice.Add(item);
        //        }
        //        var viewModel = new CarServiceViewModel
        //        {
        //            Cars = car,
        //            PastServices = listofservice,
        //            serviceTypes = serviceType
        //        };
        //        return View(viewModel);
        //    }
        //        //GET:Car
        //    //    public ActionResult ViewService()
        //    //{
        //    //    IEnumerable<Service> service;
        //    //    HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ServiceAPI").Result;
        //    //    service = response.Content.ReadAsAsync<IEnumerable<Service>>().Result;

        //    //    var id = HttpContext.User.Identity.GetUserId();

        //    //    HttpResponseMessage response1 = GlobalVariables.WebApiClient.GetAsync("Car/" + id.ToString()).Result;
        //    //    var car = response1.Content.ReadAsAsync<Car>().Result;

        //    //    HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("ServiceTypeAPI").Result;
        //    //    var serv = response2.Content.ReadAsAsync<ServiceType>().Result;

        //    //    //   HttpResponseMessage response2 = GlobalVariables.WebApiClient.GetAsync("ServiceAPI/" + id.ToString()).Result;
        //    //    //var serv = response1.Content.ReadAsAsync<Car>().Result;
        //    //    var viewModel = new CarServiceViewModel()
        //    //    {
        //    //        Cars = car,
        //    //        //PastServices = listofservice
        //    //        // serviceTypes = serv
        //    //    };
        //    //    return View(viewModel);

        //    //}
        //    public ActionResult Create()
        //    {
        //        return View(new Service());
        //    }
        //    //POST:Create Service
        //    [HttpPost]
        //    public ActionResult CreateService(CarServiceViewModel cs)
        //    {
        //        cs.Services.CarId = cs.Cars.Id;
        //        HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ServiceAPI", cs.Services).Result;
        //        return RedirectToAction("ViewService", cs.Services);
        //    }
        //    //Delete Service
        //    public ActionResult Delete(Service service)
        //    {
        //        HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ServiceAPI/" + service.Id).Result;
        //        //TempData["SuccessMessage"] = "Deleted Successfully";
        //        return RedirectToAction("ViewService");
        //    }

        //}
    