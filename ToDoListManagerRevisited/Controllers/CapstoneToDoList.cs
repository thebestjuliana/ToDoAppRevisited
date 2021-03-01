using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagerRevisited.Models;

namespace ToDoListManagerRevisited.Controllers
{
    [Authorize]
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
            assignment.AssignmentCompletionStatus = false;
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
            return RedirectToAction("Error");
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult ViewAll()
        {
            return View(_capstoneToDoList.Assignment.Where(x => x.AssignedUserName == User.Identity.Name).ToList());
        }

        [HttpPost]
        public IActionResult ViewAll(int AssignmentId)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(AssignmentId);
            return RedirectToAction("ViewAssignment", assignment);
        }
        public IActionResult Delete(int id)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(id);
            return View(assignment);

        }
        [HttpPost]
        public IActionResult Delete(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _capstoneToDoList.Assignment.Remove(assignment);
                _capstoneToDoList.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            else
            {
                return RedirectToAction("Error");
            }

            
        }

        public IActionResult MarkComplete(int id)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(id);
            
            return View(assignment);
        }
        [HttpPost]

        public IActionResult MarkComplete(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _capstoneToDoList.Assignment.Update(assignment);
                _capstoneToDoList.SaveChanges();
                return RedirectToAction("ViewAssignment", assignment);
            }
            return RedirectToAction("Error");
        }
        public IActionResult ViewIncomplete()
        {
            return View(_capstoneToDoList.Assignment.Where(x => x.AssignedUserName == User.Identity.Name && x.AssignmentCompletionStatus ==false).ToList());
        }

        [HttpPost]
        public IActionResult ViewIncomplete(int AssignmentId)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(AssignmentId);
            return RedirectToAction("ViewAssignment", assignment);
        }
        public IActionResult ViewComplete()
        {
            return View(_capstoneToDoList.Assignment.Where(x => x.AssignedUserName == User.Identity.Name && x.AssignmentCompletionStatus == true).ToList());
        }

        [HttpPost]
        public IActionResult ViewComplete(int AssignmentId)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(AssignmentId);
            return RedirectToAction("ViewAssignment", assignment);
        }

        public IActionResult FilterByDate(DateTime startDate, DateTime endDate)
        {
            return View(_capstoneToDoList.Assignment.Where(x => x.AssignedUserName == User.Identity.Name && x.AssignmentDueDate >= startDate && x.AssignmentDueDate <= endDate).ToList());
        }
        
        public IActionResult FilterId(int AssignmentId)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(AssignmentId);
            return RedirectToAction("ViewAssignment", assignment);
        }

        public IActionResult UpdateDate(int id)
        {
            Assignment assignment = _capstoneToDoList.Assignment.Find(id);

            return View(assignment);
        }
        [HttpPost]

        public IActionResult UpdateDate(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _capstoneToDoList.Assignment.Update(assignment);
                _capstoneToDoList.SaveChanges();
                return RedirectToAction("ViewAssignment", assignment);
            }
            return RedirectToAction("Error");
        }
    }
}
