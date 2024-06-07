using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VolkanKarakulakPortfolio.Data;
using VolkanKarakulakPortfolio.Models;

namespace VolkanKarakulakPortfolio.Controllers
{
    public class EducationContentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducationContentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EducationContents
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationContent.ToListAsync());
        }

        // GET: EducationContents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationContent = await _context.EducationContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationContent == null)
            {
                return NotFound();
            }

            return View(educationContent);
        }

        // GET: EducationContents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationContents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PublisedDate,Description")] EducationContent educationContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationContent);
        }

        // GET: EducationContents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationContent = await _context.EducationContent.FindAsync(id);
            if (educationContent == null)
            {
                return NotFound();
            }
            return View(educationContent);
        }

        // POST: EducationContents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PublisedDate,Description")] EducationContent educationContent)
        {
            if (id != educationContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationContentExists(educationContent.Id))
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
            return View(educationContent);
        }

        // GET: EducationContents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationContent = await _context.EducationContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationContent == null)
            {
                return NotFound();
            }

            return View(educationContent);
        }

        // POST: EducationContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationContent = await _context.EducationContent.FindAsync(id);
            if (educationContent != null)
            {
                _context.EducationContent.Remove(educationContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationContentExists(int id)
        {
            return _context.EducationContent.Any(e => e.Id == id);
        }
    }
}
