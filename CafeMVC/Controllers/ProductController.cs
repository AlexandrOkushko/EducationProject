using CafeDAL.Models;
using CafeDAL.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using CafeDAL.Repos.Interfaces;

namespace CafeMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepo _repo;

        public ProductController(IProductsRepo repo)
        {
            _repo = repo;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: Product/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = _repo.GetOne(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,ExpirationDate,Price,SupplierId")] Products product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            try
            {
                _repo.Add(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to create record: {ex.Message}");
                return View(product);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Edit/5
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

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,ExpirationDate,Price,SupplierId,Id,Timestamp")] Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            try
            {
                _repo.Update(product);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty,
                    $@"Unable to save the record. Another user has updated it. {ex.Message}");
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $@"Unable to save the record. {ex.Message}");
                return View(product);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Delete/5
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

        // POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id,Timestamp")] Products product)
        {
            try
            {
                _repo.Delete(product);
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