using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelationshipsTest.Data;
using RelationshipsTest.Models;

namespace RelationshipsTest.Controllers
{
    public class BlogImagesController : Controller
    {
        private readonly RelationshipsTestContext _context;

        public BlogImagesController(RelationshipsTestContext context)
        {
            _context = context;
        }

        // GET: BlogImages
        public async Task<IActionResult> Index()
        {
            var relationshipsTestContext = _context.BlogImages.Include(b => b.Blog);
            return View(await relationshipsTestContext.ToListAsync());
        }

        // GET: BlogImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogImage = await _context.BlogImages
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.BlogImageId == id);
            if (blogImage == null)
            {
                return NotFound();
            }

            return View(blogImage);
        }

        // GET: BlogImages/Create
        public IActionResult Create()
        {
            ViewData["BlogForeignKey"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            return View();
        }

        // POST: BlogImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogImageId,Image,Caption,BlogForeignKey")] BlogImage blogImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BlogForeignKey"] = new SelectList(_context.Blogs, "BlogId", "BlogId", blogImage.BlogForeignKey);
            return View(blogImage);
        }

        // GET: BlogImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogImage = await _context.BlogImages.FindAsync(id);
            if (blogImage == null)
            {
                return NotFound();
            }
            ViewData["BlogForeignKey"] = new SelectList(_context.Blogs, "BlogId", "BlogId", blogImage.BlogForeignKey);
            return View(blogImage);
        }

        // POST: BlogImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogImageId,Image,Caption,BlogForeignKey")] BlogImage blogImage)
        {
            if (id != blogImage.BlogImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogImageExists(blogImage.BlogImageId))
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
            ViewData["BlogForeignKey"] = new SelectList(_context.Blogs, "BlogId", "BlogId", blogImage.BlogForeignKey);
            return View(blogImage);
        }

        // GET: BlogImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogImage = await _context.BlogImages
                .Include(b => b.Blog)
                .FirstOrDefaultAsync(m => m.BlogImageId == id);
            if (blogImage == null)
            {
                return NotFound();
            }

            return View(blogImage);
        }

        // POST: BlogImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogImage = await _context.BlogImages.FindAsync(id);
            _context.BlogImages.Remove(blogImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogImageExists(int id)
        {
            return _context.BlogImages.Any(e => e.BlogImageId == id);
        }
    }
}
