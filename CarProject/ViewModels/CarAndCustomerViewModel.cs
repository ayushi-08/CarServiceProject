using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.ViewModels
{
    public class CarAndCustomerViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Car> Cars { get; set; }
        public ApplicationUser User { get; set; }

    }
}