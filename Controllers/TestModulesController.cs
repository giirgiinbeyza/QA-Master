using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DermaLogic.Models;
using DermaLogic.Data;

namespace DermaLogic.Controllers
{
    public class TestModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TestModules.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModule = await _context.TestModules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModule == null)
            {
                return NotFound();
            }

            return View(testModule);
        }

        // GET: TestModules/Create
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] TestModule testModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testModule);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModule = await _context.TestModules.FindAsync(id);
            if (testModule == null)
            {
                return NotFound();
            }
            return View(testModule);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] TestModule testModule)
        {
            if (id != testModule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestModuleExists(testModule.Id))
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
            return View(testModule);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModule = await _context.TestModules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModule == null)
            {
                return NotFound();
            }

            return View(testModule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testModule = await _context.TestModules.FindAsync(id);
            if (testModule != null)
            {
                _context.TestModules.Remove(testModule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestModuleExists(int id)
        {
            return _context.TestModules.Any(e => e.Id == id);
        }
    }
}
