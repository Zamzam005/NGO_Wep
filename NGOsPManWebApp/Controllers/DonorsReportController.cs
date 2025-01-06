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
    public class DonorsReportController : Controller
    {
        private readonly WebDbContext _context;

        public DonorsReportController(WebDbContext context)
        {
            _context = context;
        }

        // GET: DonorsReport
        public async Task<IActionResult> Index()
        {
            var webDbContext = _context.tbl_Donor.Include(d => d.Project);
            return View(await webDbContext.ToListAsync());
        }

        // GET: DonorsReport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.tbl_Donor
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // GET: DonorsReport/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name");
            return View();
        }

        // POST: DonorsReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorId,DonorName,Address,Number,Email,Don_Amount,Don_Date,Don_Type,ProjectId")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", donor.ProjectId);
            return View(donor);
        }

        // GET: DonorsReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.tbl_Donor.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", donor.ProjectId);
            return View(donor);
        }

        // POST: DonorsReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,DonorName,Address,Number,Email,Don_Amount,Don_Date,Don_Type,ProjectId")] Donor donor)
        {
            if (id != donor.DonorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.DonorId))
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
            ViewData["ProjectId"] = new SelectList(_context.tbl_Project, "ProjectId", "Project_name", donor.ProjectId);
            return View(donor);
        }

        // GET: DonorsReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.tbl_Donor
                .Include(d => d.Project)
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: DonorsReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.tbl_Donor.FindAsync(id);
            if (donor != null)
            {
                _context.tbl_Donor.Remove(donor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
            return _context.tbl_Donor.Any(e => e.DonorId == id);
        }
    }
}
