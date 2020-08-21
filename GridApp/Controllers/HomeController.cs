using GridApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace GridApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext context;

        public HomeController()
        {
            context = new ApplicationContext();
        }

        public ActionResult Index()
        {
            return View();
        }
        public string GetHrs()
        {
            string json = "{\n \"rows\": [\n";
            foreach (var item in context.HRs)
            {
                json += "{ \"i\": " + $"\"{item.Id}\", \"data\": [\"{item.Id}\", \"{item.Name}\"]" + "},\n";
            }
            json = json.Remove(json.Length - 2);
            json += "] \n}";

            return JsonConvert.SerializeObject(json);
        }
        public string GetEmployees()
        {
            string json = "{\n \"rows\": [\n";
            foreach (var item in context.Employees)
            {
                json += "{ \"i\": " + $"\"{item.Id}\", \"data\": [\"{item.Id}\", \"{item.Name}\"]" + "},\n";
            }
            json = json.Remove(json.Length - 2);
            json += "] \n}";

            return JsonConvert.SerializeObject(json);
        }
    }
}