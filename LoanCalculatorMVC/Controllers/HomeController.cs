using LoanCalculatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LoanCalculatorMVC.Helpers;

namespace LoanCalculatorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult App()
        {
            Loan loan = new();

            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 3.5m;
            loan.Amount = 15000.0m;
            loan.Term = 60;

            return View(loan);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult App(Loan loan)
        {
            //calculate the loan and get the payments
            var loanHelper = new LoanHelper();

            Loan newloan = loanHelper.GetPayments(loan);


            return View(newloan);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}