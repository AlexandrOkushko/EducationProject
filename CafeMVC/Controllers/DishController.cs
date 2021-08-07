using CafeDAL.Models;
using CafeDAL.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CafeDAL.Repos.Interfaces;

namespace CafeMVC.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepo _repo;

        public DishController(IDishRepo repo)
        {
            _repo = repo;
        }

        // GET: DishController
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: DishController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dish = _repo.GetOne(id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: DishController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,ExpirationDate,Price,IsActual")] Dishes dish)
        {
            if (!ModelState.IsValid)
            {
                return View(dish);
            }
            try
            {
                _repo.Add(dish);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(dish);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DishController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dish = _repo.GetOne(id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Description,ExpirationDate,Price,IsActual,Id,Timestamp")] Dishes dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dish);
            }

            try
            {
                _repo.Update(dish);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty,
                    $@"Unable to save the record. Another user has updated it. {ex.Message}");
                return View(dish);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                return View(dish);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DishController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var dish = _repo.GetOne(id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id,Timestamp")] Dishes dish)
        {
            try
            {
                _repo.Delete(dish);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty,
                    $@"Unable to delete record. Another user updated the record. {ex.Message}");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}