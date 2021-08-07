using CafeDAL.Models;
using CafeDAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeDAL.Repos.Interfaces;

namespace CafeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _repo;

        public EmployeeController(IEmployeeRepo repo)
        {
            _repo = repo;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/List
        public ActionResult List(int id)
        {
            return View(_repo.GetAll());
        }


        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = _repo.GetOne(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,PassportId,INN,BirdthDate,GenderId,Phone,RoleId,Email,Password")] Employees Employee)
        {
            if (!ModelState.IsValid)
            {
                return View(Employee);
            }
            try
            {
                _repo.Add(Employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(Employee);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
