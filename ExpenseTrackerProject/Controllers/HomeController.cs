 using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Services.Interfaces;
using ExpenseTrackerProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly IIncomeService _incomeService;
        private readonly ICategoryService _categoryService;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IBudgetService _budgetService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger,
                              IExpenseService expenseService,
                              IIncomeService incomeService,
                              ICategoryService categoryService,
                              IPaymentMethodService paymentMethodService,
                              IBudgetService budgetService,
                              IUserService userService)
        {
            _logger = logger;
            _expenseService = expenseService;
            _incomeService = incomeService;
            _categoryService = categoryService;
            _paymentMethodService = paymentMethodService;
            _budgetService = budgetService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
        public IActionResult Expenses()
        {
            var expenses = _expenseService.GetAllExpenses();
            return View(expenses);
        }

        public IActionResult Incomes()
        {
            var incomes = _incomeService.GetAllIncomes();
            return View(incomes);
        }

        public IActionResult Categories()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult PaymentMethods()
        {
            var paymentMethods = _paymentMethodService.GetAllPaymentMethods();
            return View(paymentMethods);
        }

        public IActionResult Budgets()
        {
            var budgets = _budgetService.GetAllBudgets();
            return View(budgets);
        }

        public IActionResult Users()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

        // search functionality for all pages
        public IActionResult Search(string query)
        {

            var users = _userService.GetAllUsers().Where(u => u.Name.ToLower().Contains(query) || u.Email.ToLower().Contains(query)).ToList();
            var categories = _categoryService.GetAllCategories().Where(c => c.Name.ToLower().Contains(query) || c.CreatedAt.ToString().Contains(query)).ToList();
            var expenses = _expenseService.GetAllExpenses().Where(e => e.Description.ToLower().Contains(query) || e.Amount.ToString().Contains(query) || e.CreatedAt.ToString().Contains(query)).ToList();
            var incomes = _incomeService.GetAllIncomes().Where(i => i.Description.ToLower().Contains(query) || i.Amount.ToString().Contains(query) || i.CreatedAt.ToString().Contains(query)).ToList();
            var budgets = _budgetService.GetAllBudgets().Where(b => b.Amount.ToString().Contains(query) || b.CreatedAt.ToString().Contains(query)).ToList();
            var paymentMethods = _paymentMethodService.GetAllPaymentMethods().Where(p => p.Name.ToLower().Contains(query) || p.CreatedAt.ToString().Contains(query)).ToList();

            var searchResults = new SearchResultsViewModel
            {
                Query = query,
                Users = users,
                Categories = categories,
                Expenses = expenses,
                Incomes = incomes,
                Budgets = budgets,
                PaymentMethods = paymentMethods
            };

            return View(searchResults);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}