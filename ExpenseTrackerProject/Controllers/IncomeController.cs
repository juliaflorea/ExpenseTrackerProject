using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using ExpenseTrackerProject.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerProject.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IUserService _userService;


        public IncomeController(IIncomeService incomeService, IUserService userService)
        {
            _incomeService = incomeService;
            _userService = userService;


        }
        
        public IActionResult Index()
        {
            var incomes = _incomeService.GetAllIncomes();
            return View(incomes);

        }

        public IActionResult Details(int id)
        {
            var income = _incomeService.GetIncomeById(id);
            if (income == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", income.UserId);
            return View(income);
        }


      //  [Authorize]
        // GET: Income/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers().ToList(), "UserId", "Name");

            return View();

        }

        // POST: Income/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("IncomeId,UserId,Description,Amount,CreatedAt")] Income income)
        {
            if (ModelState.IsValid)
            {
                _incomeService.AddIncome(income);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", income.UserId);
            
            return View(income);
        }


       // [Authorize]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income =  _incomeService.GetIncomeById(id);
            if (income == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name",income.UserId);
            
            return View(income);
        }

       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("IncomeId, UserId,Description,Amount,CreatedAt")] Income income)
        {
            if (id != income.IncomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _incomeService.UpdateIncome(income);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while updating the income: {ex.Message}");
                }
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", income.UserId);
            return View(income);
        }

       // [Authorize]
        public IActionResult Delete(int id)
        {
            var income = _incomeService.GetIncomeById(id);
            if (income == null)
            {
                return NotFound();
            }
            return View(income);
        }

      //  [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _incomeService.DeleteIncome(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
