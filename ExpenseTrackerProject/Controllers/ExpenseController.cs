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
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IPaymentMethodService _paymentMethodService;



        public ExpenseController(IExpenseService expenseService, IUserService userService,
        ICategoryService categoryService, IPaymentMethodService paymentMethodService)
        {
            _expenseService = expenseService;
            _userService = userService;
            _categoryService = categoryService;
            _paymentMethodService = paymentMethodService;
        }

      
        public IActionResult Index()
        {
            var expenses = _expenseService.GetAllExpenses();
            return View(expenses.ToList());
        }

        
        // GET: Expense/Details/5
        public IActionResult Details(int id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", expense.UserId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", expense.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_paymentMethodService.GetAllPaymentMethods(), "PaymentMethodId", "Name", expense.PaymentMethodId);
            return View(expense);

        }

//[Authorize]
        // GET: Expense/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
            ViewData["PaymentMethodId"] = new SelectList(_paymentMethodService.GetAllPaymentMethods(), "PaymentMethodId", "Name");
            return View();
        }

       // [Authorize]
        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserId, CategoryId, PaymentMethodId, ExpenseId,Description")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expenseService.AddExpense(expense);
                _expenseService.Save();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", expense.UserId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", expense.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_paymentMethodService.GetAllPaymentMethods(), "PaymentMethodId", "Name", expense.PaymentMethodId);
            return View(expense);
        }

       // [Authorize]
        public IActionResult Edit(int id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", expense.UserId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", expense.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_paymentMethodService.GetAllPaymentMethods(), "PaymentMethodId", "Name", expense.PaymentMethodId);
            return View(expense);
        }

       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _expenseService.UpdateExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_userService.GetAllUsers(), "UserId", "Name", expense.UserId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", expense.CategoryId);
            ViewData["PaymentMethodId"] = new SelectList(_paymentMethodService.GetAllPaymentMethods(), "PaymentMethodId", "Name", expense.PaymentMethodId);
            return View(expense);
        }

       // [Authorize]
        public IActionResult Delete(int id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

       // [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _expenseService.DeleteExpense(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
