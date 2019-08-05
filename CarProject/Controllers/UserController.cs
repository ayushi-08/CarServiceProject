using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult ViewCustomers()
        {
            IEnumerable<ApplicationUser> user;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("User").Result;
            user = response.Content.ReadAsAsync<IEnumerable<ApplicationUser>>().Result;
            return View(user);


        }
        public ActionResult Create()
        {
            return View(new ApplicationUser());
        }
       // [Authorize(Roles = Roles.Admin)]
        // POST: User/Create
        [HttpPost]  
        public ActionResult CreateCust(ApplicationUser user)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", user).Result;
            //TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("ViewCustomers");
        }
         
        // GET: Users/Edit/
        public ActionResult Edit(RegisterViewModel register)
        {
            return View(register);
        }
        [HttpPost]
        public ActionResult Update(RegisterViewModel register)
        {
            HttpResponseMessage response1 = GlobalVariables.WebApiClient.PutAsJsonAsync("User", register).Result;
            TempData["SuccessMessage"] = "Updated Successfully";
            return RedirectToAction("ViewCustomers");
        }
        public ActionResult Delete(ApplicationUser user)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("User/" + user.Id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("ViewCustomers");
        }

    }
}