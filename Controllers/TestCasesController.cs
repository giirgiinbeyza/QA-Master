using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DermaLogic.Models;
using System.IO;
using DermaLogic.Data;
using Microsoft.AspNetCore.Authorization;

namespace DermaLogic.Controllers
{
    public class TestCasesController : Controller
    {
        private readonly ApplicationDbContext _context ;

        public TestCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string statusFilter)
        {
            var tests = _context.TestCases.Include(t => t.TestModule).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                tests = tests.Where(s => s.Title.Contains(searchString) || s.Steps.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(statusFilter))
            {
                tests = tests.Where(s => s.Status == statusFilter);
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentStatus = statusFilter;

            return View(await tests.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var testCase = await _context.TestCases
                .Include(t => t.TestModule)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (testCase == null) return NotFound();

            return View(testCase);
        }

        public IActionResult Create()
        {
            ViewData["TestModuleId"] = new SelectList(_context.TestModules, "Id", "Name");

            ViewData["UserList"] = new SelectList(_context.users, "userName", "userName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Steps,Priority,Status,CreatedDate,TestModuleId,TestType,ExpectedResult,AssignedTo")] TestCase testCase, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    
                    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

                    var location = Path.Combine(directoryPath, newImageName);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    testCase.ImagePath = newImageName;
                }

                _context.Add(testCase);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Harika! Test senaryosu başarıyla oluşturuldu.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestModuleId"] = new SelectList(_context.TestModules, "Id", "Name", testCase.TestModuleId);
            return View(testCase);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase == null) return NotFound();
            
            ViewData["TestModuleId"] = new SelectList(_context.TestModules, "Id", "Name", testCase.TestModuleId);
            ViewData["UserList"] = new SelectList(_context.users, "userName", "userName", testCase.AssignedTo);
            return View(testCase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Steps,Priority,Status,CreatedDate,TestModuleId,TestType,ExpectedResult,AssignedTo")] TestCase testCase)
        {
            if (id != testCase.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCaseExists(testCase.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TestModuleId"] = new SelectList(_context.TestModules, "Id", "Name", testCase.TestModuleId);
            return View(testCase);
        }

        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var testCase = await _context.TestCases
                .Include(t => t.TestModule)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (testCase == null) return NotFound();

            return View(testCase);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase != null) _context.TestCases.Remove(testCase);
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestCaseExists(int id)
        {
            return _context.TestCases.Any(e => e.Id == id);
        }
    }
}