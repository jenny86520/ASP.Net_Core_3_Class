using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreTest.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ContosouniversityContext _context;
        public CoursesController(ContosouniversityContext context)
        {
            _context = context;
        }
        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesAsync()
        {
            /** Class-1208: 將導覽屬性放入一起回傳 */
            return await _context.Course
            .Include(c => c.Department)
            .Include(c => c.CourseInstructor)
            .Include(c => c.Enrollment)
            .ToListAsync();
        }

        // GET api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourseAsync(int id)
        {
            /** Class-1208: 將 GetCourseById 回傳結果包含所有講師姓名與 Person.ID 欄位 */
            var course = await (
                from c in _context.Course
                where c.CourseId == id && c.Department.DepartmentId > 1
                select new
                {
                    c.CourseId,
                    c.Title,
                    c.Credits,
                    c.DepartmentId,
                    DepartmentName = c.Department.Name,
                    Instructors = c.CourseInstructor.Select(x => new
                    {
                        x.InstructorId,
                        InstructorFirstName = x.Instructor.FirstName,
                        InstructorLastname = x.Instructor.LastName
                    })
                }
            ).SingleAsync();

            if (course == null)
            {
                return NotFound();
            }

            return new JsonResult(course);
        }

        // POST api/Courses
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Courses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Courses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
