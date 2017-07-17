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
        public IActionResult Create(PeopleCreateVM person)
        {
            if (!ModelState.IsValid)
                return View(person);

            DataManager.AddPerson(person);
            return RedirectToAction(nameof (Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var person = DataManager.GetAPerson(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(int id, PeopleEditVM person)
        {
            if (!ModelState.IsValid)
                return View(person);

            DataManager.EditPerson(id,person);
            return RedirectToAction(nameof (Index));
        }
    }
}
