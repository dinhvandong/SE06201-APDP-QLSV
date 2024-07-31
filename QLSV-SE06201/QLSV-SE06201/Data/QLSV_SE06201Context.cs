using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLSV_SE06201.Models;

namespace QLSV_SE06201.Data
{
    public class QLSV_SE06201Context : DbContext
    {
        public QLSV_SE06201Context (DbContextOptions<QLSV_SE06201Context> options)
            : base(options)
        {
        }

        public DbSet<QLSV_SE06201.Models.Account> Account { get; set; } = default!;
        public DbSet<QLSV_SE06201.Models.Course> Course { get; set; } = default!;
        public DbSet<QLSV_SE06201.Models.Student> Student { get; set; } = default!;
        public DbSet<QLSV_SE06201.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<QLSV_SE06201.Models.CourseTeacher> CourseTeacher { get; set; } = default!;
        public DbSet<QLSV_SE06201.Models.CourseTeacherStudent> CourseTeacherStudent { get; set; } = default!;
    }
}
