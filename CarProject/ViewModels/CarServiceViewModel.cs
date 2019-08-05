using CarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.ViewModels
{
    public class CarServiceViewModel
    {
        public Car Cars { get; set; }
        public Service Services { get; set; }
        public IEnumerable<Service> PastServices { get; set; }
        public IEnumerable<ServiceType> serviceTypes { get; set; }
    }
}