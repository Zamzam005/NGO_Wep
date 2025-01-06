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
    public class TtasksReportsController : Controller
    {
        private readonly WebDbContext _context;

        public TtasksReportsController(WebDbContext context)
        {
            _context = context;
        }

        // GET: TtasksReports
        public async Task<IActionResult> Index()
        {
            var webDbContext = _context.tbl_Tasks.Include(t => t.Employee).Include(t => t.Project);
            return View(await webDbContext.ToListAsync());
        }

        // GET: TtasksReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttask = await _context.tbl_Tasks
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.TtaskId == id);
            if (ttask == null)
            {
                return NotFound();
            }

            return View(ttask);
        }

        // GET: TtasksReports/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.tbl_employee, "EmployeeId", "Emp_FullName");
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name");
            return View();
        }

        // POST: TtasksReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TtaskId,Task_Name,Due_Date,Status,ProjectId,EmployeeId")] Ttask ttask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.tbl_employee, "EmployeeId", "Emp_FullName", ttask.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", ttask.ProjectId);
            return View(ttask);
        }

        // GET: TtasksReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttask = await _context.tbl_Tasks.FindAsync(id);
            if (ttask == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.tbl_employee, "EmployeeId", "Emp_FullName", ttask.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", ttask.ProjectId);
            return View(ttask);
        }

        // POST: TtasksReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TtaskId,Task_Name,Due_Date,Status,ProjectId,EmployeeId")] Ttask ttask)
        {
            if (id != ttask.TtaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ttask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TtaskExists(ttask.TtaskId))
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
            ViewData["EmployeeId"] = new SelectList(_context.tbl_employee, "EmployeeId", "Emp_FullName", ttask.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", ttask.ProjectId);
            return View(ttask);
        }

        // GET: TtasksReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ttask = await _context.tbl_Tasks
                .Include(t => t.Employee)
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.TtaskId == id);
            if (ttask == null)
            {
                return NotFound();
            }

            return View(ttask);
        }

        // POST: TtasksReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ttask = await _context.tbl_Tasks.FindAsync(id);
            if (ttask != null)
            {
                _context.tbl_Tasks.Remove(ttask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TtaskExists(int id)
        {
            return _context.tbl_Tasks.Any(e => e.TtaskId == id);
        }
    }
}
