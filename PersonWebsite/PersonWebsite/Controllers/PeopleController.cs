using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonWebsite.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonWebsite.Controllers
{
    public class PeopleController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var people = DataManager.GetAllPeople();

            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            DataManager.AddPerson(person);
            return Redirect(nameof (Index));
        }

        public IActionResult Edit(int id)
        {
            var person = DataManager.GetAPerson(id);
            return View(person);
        }
    }
}
