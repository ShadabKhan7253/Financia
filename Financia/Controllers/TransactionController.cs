using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Financia.Data;
using Financia.Models;

namespace Financia.Controllers
{
    public class TransactionController : Controller
    {
        private readonly DataDBContext _context;

        public TransactionController(DataDBContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            var dataDBContext = _context.Transaction.Include(t => t.Category);
            return View(await dataDBContext.ToListAsync());
        }

        

        // GET: Transaction/Create
        public IActionResult AddOrEdit()
        {
            populateCaregories();
            return View(new Transaction());
        }

        // POST: Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,CategoryId,Amount,Note,Date")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            populateCaregories();
            return View(transaction);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public void populateCaregories()
        {
            var CategoryCollection = _context.Category.ToList();
            Category DefaultCategory = new Category() { CategoryId = 0, Title = "Choose a category" };
            CategoryCollection.Insert(0, DefaultCategory);
            ViewBag.Category = CategoryCollection;
        }
    }
}
