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
    public class CourseTeacherStudentsController : Controller
    {
        private readonly QLSV_SE06201Context _context;

        public CourseTeacherStudentsController(QLSV_SE06201Context context)
        {
            _context = context;
        }

        // GET: CourseTeacherStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseTeacherStudent.ToListAsync());
        }

        // GET: CourseTeacherStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacherStudent = await _context.CourseTeacherStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacherStudent == null)
            {
                return NotFound();
            }

            return View(courseTeacherStudent);
        }

        // GET: CourseTeacherStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseTeacherStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,TeacherId,StudentId")] CourseTeacherStudent courseTeacherStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTeacherStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseTeacherStudent);
        }

        // GET: CourseTeacherStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacherStudent = await _context.CourseTeacherStudent.FindAsync(id);
            if (courseTeacherStudent == null)
            {
                return NotFound();
            }
            return View(courseTeacherStudent);
        }

        // POST: CourseTeacherStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,TeacherId,StudentId")] CourseTeacherStudent courseTeacherStudent)
        {
            if (id != courseTeacherStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTeacherStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTeacherStudentExists(courseTeacherStudent.Id))
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
            return View(courseTeacherStudent);
        }

        // GET: CourseTeacherStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacherStudent = await _context.CourseTeacherStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTeacherStudent == null)
            {
                return NotFound();
            }

            return View(courseTeacherStudent);
        }

        // POST: CourseTeacherStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTeacherStudent = await _context.CourseTeacherStudent.FindAsync(id);
            if (courseTeacherStudent != null)
            {
                _context.CourseTeacherStudent.Remove(courseTeacherStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTeacherStudentExists(int id)
        {
            return _context.CourseTeacherStudent.Any(e => e.Id == id);
        }
    }
}
