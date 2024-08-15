using Financia.Data;
using Financia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financia.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DataDBContext _context;
        public DashboardController(DataDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {

            // Last 7 days
            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transaction
                .Include(x => x.Category)
                .Where(y => y.Date >= startDate && y.Date <= endDate)
                .ToListAsync();

            // Total Income
            int totalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);
            ViewBag.TotalInCome = totalIncome.ToString("C0");

            // Total Expense
            int totalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);
            ViewBag.TotalExpense = totalExpense.ToString("C0");

            // Balance 
            int balance = totalIncome - totalExpense;
            ViewBag.Balance = balance.ToString("C0");

            return View();
        }
    }
}
