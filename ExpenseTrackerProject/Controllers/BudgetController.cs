using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Services.Interfaces;
using ExpenseTrackerProject.Services;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerProject.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public BudgetController(IBudgetService budgetService, IUserService userService, ICategoryService categoryService)
        {
            _budgetService = budgetService;
            _userService = userService;
            _categoryService = categoryService;
        }

        // GET: Budget
        
        public ActionResult Index()
        {
            var budgets = _budgetService.GetAllBudgets();
            return View(budgets);
        }

        // GET: Budget/Details/5
      
        public ActionResult Details(int id)
        {
            var budget = _budgetService.GetBudgetById(id);

            if (budget == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", budget.UserId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Nme", budget.CategoryId);
            return View(budget);
        }

        // GET: Budget/Create
       // [Authorize]
        public ActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
           
            return View();
        }

        // POST: Budget/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("BudgetId,UserId,CategoryId,Amount,CreatedAt")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                _budgetService.AddBudget(budget);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");

            return View(budget);
        }

       // [Authorize]
        // GET: Budget/Edit/5
        public ActionResult Edit(int id)
        {
            var budget = _budgetService.GetBudgetById(id);

            if (budget == null)
            {
                return NotFound();
            }

            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
            return View(budget);
        }

        // POST: Budget/Edit/5
       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("BudgetId,UserId,CategoryId,Amount,CreatedAt")] Budget budget)
        {
            if (id != budget.BudgetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _budgetService.UpdateBudget(budget);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while updating the budget: {ex.Message}");
                }
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
            return View(budget);
        }

      //  [Authorize]
        // GET: Budget/Delete/5
        public ActionResult Delete(int id)
        {
            var budget = _budgetService.GetBudgetById(id);

            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _budgetService.DeleteBudget(id);
            return RedirectToAction(nameof(Index));
        }
    }


    




}
