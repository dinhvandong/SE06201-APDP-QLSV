using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLSV_SE06201.Data;
using QLSV_SE06201.Models;

namespace QLSV_SE06201.Controllers
{
    public class CourseTeachersController : Controller
    {
        private readonly QLSV_SE06201Context _context;

        public CourseTeachersController(QLSV_SE06201Context context)
        {
            _context = context;
        }

        // GET: CourseTeachers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseTeacher.ToListAsync());
        }

        // GET: CourseTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // GET: CourseTeachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,TeacherId")] CourseTeacher courseTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher.FindAsync(id);
            if (courseTeacher == null)
            {
                return NotFound();
            }
            return View(courseTeacher);
        }

        // POST: CourseTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,TeacherId")] CourseTeacher courseTeacher)
        {
            if (id != courseTeacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTeacherExists(courseTeacher.Id))
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
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // POST: CourseTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTeacher = await _context.CourseTeacher.FindAsync(id);
            if (courseTeacher != null)
            {
                _context.CourseTeacher.Remove(courseTeacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTeacherExists(int id)
        {
            return _context.CourseTeacher.Any(e => e.Id == id);
        }
    }
}
