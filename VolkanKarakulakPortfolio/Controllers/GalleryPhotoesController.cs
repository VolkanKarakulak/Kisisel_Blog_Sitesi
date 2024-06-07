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
    public class GalleryPhotoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryPhotoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GalleryPhotoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GalleryPhotos.ToListAsync());
        }

        // GET: GalleryPhotoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryPhoto = await _context.GalleryPhotos
                .FirstOrDefaultAsync(m => m.GalleryPhotoId == id);
            if (galleryPhoto == null)
            {
                return NotFound();
            }

            return View(galleryPhoto);
        }

        // GET: GalleryPhotoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GalleryPhotoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GalleryPhotoId,PhotoName,Description,Date,LocationName")] GalleryPhoto galleryPhoto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(galleryPhoto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(galleryPhoto);
        }

        // GET: GalleryPhotoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryPhoto = await _context.GalleryPhotos.FindAsync(id);
            if (galleryPhoto == null)
            {
                return NotFound();
            }
            return View(galleryPhoto);
        }

        // POST: GalleryPhotoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GalleryPhotoId,PhotoName,Description,Date,LocationName")] GalleryPhoto galleryPhoto)
        {
            if (id != galleryPhoto.GalleryPhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(galleryPhoto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryPhotoExists(galleryPhoto.GalleryPhotoId))
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
            return View(galleryPhoto);
        }

        // GET: GalleryPhotoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryPhoto = await _context.GalleryPhotos
                .FirstOrDefaultAsync(m => m.GalleryPhotoId == id);
            if (galleryPhoto == null)
            {
                return NotFound();
            }

            return View(galleryPhoto);
        }

        // POST: GalleryPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var galleryPhoto = await _context.GalleryPhotos.FindAsync(id);
            if (galleryPhoto != null)
            {
                _context.GalleryPhotos.Remove(galleryPhoto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryPhotoExists(int id)
        {
            return _context.GalleryPhotos.Any(e => e.GalleryPhotoId == id);
        }
    }
}
