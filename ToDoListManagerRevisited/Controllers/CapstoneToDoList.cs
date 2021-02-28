using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagerRevisited.Models;

namespace ToDoListManagerRevisited.Controllers
{
    public class CapstoneToDoListController : Controller
    {
        private readonly CapstoneToDoListContext _capstoneToDoList;
        public CapstoneToDoListController(CapstoneToDoListContext capstoneToDoListContext)
        {
            _capstoneToDoList = capstoneToDoListContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAssignment()
        {
            return View(_capstoneToDoList.AspNetUsers.ToList());
        }
        [HttpPost]
        public IActionResult CreateAssignment(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _capstoneToDoList.Assignment.Add(assignment);
                _capstoneToDoList.SaveChanges();
                return RedirectToAction("ViewAssignment", assignment);
            }
            else
            {
                return View();
            }
        }
        public IActionResult ViewAssignment(Assignment assignment)
        {
            return View(assignment);
        }
        public IActionResult Update(int id)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(id);
            return View(assignment);
        }
        [HttpPost]

        public IActionResult Update(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _capstoneToDoList.Assignment.Update(assignment);
                _capstoneToDoList.SaveChanges();
                return RedirectToAction("ViewAssignment", assignment);
            }
            else
            {
                //make this action/view!!!
                return RedirectToAction("InvalidUpdate");
            }
        }
    }
}
