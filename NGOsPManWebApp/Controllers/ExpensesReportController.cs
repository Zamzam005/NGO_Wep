 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGOsPManWebApp.Data;
using NGOsPManWebApp.Models;

namespace NGOsPManWebApp.Controllers
{
    public class ExpensesReportController : Controller
    {
        private readonly WebDbContext _context;

        public ExpensesReportController(WebDbContext context)
        {
            _context = context;
        }

        // GET: ExpensesReport
        public async Task<IActionResult> Index()
        {
            var webDbContext = _context.tbl_Expense.Include(e => e.Project);
            return View(await webDbContext.ToListAsync());
        }

        // GET: ExpensesReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.tbl_Expense
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: ExpensesReport/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name");
            return View();
        }

        // POST: ExpensesReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,Amount,Expense_Type,Date,ProjectId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", expense.ProjectId);
            return View(expense);
        }

        // GET: ExpensesReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.tbl_Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", expense.ProjectId);
            return View(expense);
        }

        // POST: ExpensesReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,Amount,Expense_Type,Date,ProjectId")] Expense expense)
        {
            if (id != expense.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.ExpenseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", expense.ProjectId);
            return View(expense);
        }

        // GET: ExpensesReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.tbl_Expense
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: ExpensesReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.tbl_Expense.FindAsync(id);
            if (expense != null)
            {
                _context.tbl_Expense.Remove(expense);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.tbl_Expense.Any(e => e.ExpenseId == id);
        }
    }
}
