using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ExpenseTrackerProject.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

       
        public IActionResult Index()
        {
            var paymentMethods = _paymentMethodService.GetAllPaymentMethods();
            return View(paymentMethods);
        }

        // GET: PaymentMethod/Details/5
        public IActionResult Details(int id)
        {
            var paymentMethod = _paymentMethodService.GetPaymentMethodById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

       // [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PaymentMethodId,Name")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _paymentMethodService.AddPaymentMethod(paymentMethod);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethod);
        }

       // [Authorize]
        public IActionResult Edit(int id)
        {
            var paymentMethod = _paymentMethodService.GetPaymentMethodById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return View(paymentMethod);
        }

       // [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PaymentMethodId,Name")] PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.PaymentMethodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _paymentMethodService.UpdatePaymentMethod(paymentMethod);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"An error occurred while updating the payment method: {ex.Message}");
                }
            }
            return View(paymentMethod);
        }

       // [Authorize]
        public IActionResult Delete(int id)
        {
            var paymentMethod = _paymentMethodService.GetPaymentMethodById(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return View(paymentMethod);
        }

       // [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _paymentMethodService.DeletePaymentMethod(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
