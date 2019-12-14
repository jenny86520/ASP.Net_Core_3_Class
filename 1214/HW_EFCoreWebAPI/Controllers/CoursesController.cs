using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HW_EFCoreWebAPI.Models;

namespace HW_EFCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ContosouniversityContext _context;

        public CoursesController(ContosouniversityContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return await _context.Course.Where(x => x.IsDeleted == false).ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);

            if (course == null || course.IsDeleted)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /** Class-1214: 實作 PATCH API 更新一個實體的部分資料 
            Patch 實作也可參考: https://benfoster.io/blog/aspnet-core-json-patch-partial-api-updates
             */
        // PATCH: api/Courses
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCourse(int id, Course_ course_)
        {
            var course = await _context.Course.FindAsync(id);

            if (!await TryUpdateModelAsync(course))
            {
                return BadRequest();
            }

            course.Title = course_.Title;
            course.Credits = course_.Credits;
            course.IsDeleted = course_.IsDeleted;

            if(! TryValidateModel(course))
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            course.IsDeleted = true;
            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }

        /** vwCourseStudents
         * 在 CoursesController 中設計 vwCourseStudents 與 vwCourseStudentCount 檢視表的 API 輸出
         */
        // GET: api/Courses/Students
        [HttpGet("Students")]
        public async Task<ActionResult<IEnumerable<VwCourseStudents>>> GetStudents()
        {
            return await _context.VwCourseStudents.ToListAsync();
        }
        // GET: api/Courses/Students/1
        [HttpGet("Students/{id}")]
        public async Task<ActionResult<IEnumerable<VwCourseStudents>>> GetStudentsById(int id)
        {
            var student = await _context.VwCourseStudents.Where(x => x.CourseId == id).ToListAsync();

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
        /** vwCourseStudentsCount
         * 在 CoursesController 中設計 vwCourseStudents 與 vwCourseStudentCount 檢視表的 API 輸出
         */
        // GET: api/Courses/StudentsCount
        [HttpGet("StudentsCount")]
        public async Task<ActionResult<IEnumerable<VwCourseStudentCount>>> GetStudentsCount()
        {
            return await _context.VwCourseStudentCount.ToListAsync();
        }
        // GET: api/Courses/StudentsCount/1
        [HttpGet("StudentsCount/{id}")]
        public async Task<ActionResult<IEnumerable<VwCourseStudentCount>>> GetStudentsCountById(int id)
        {
            var student = await _context.VwCourseStudentCount.Where(x => x.CourseId == id).ToListAsync();

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

    }
}
