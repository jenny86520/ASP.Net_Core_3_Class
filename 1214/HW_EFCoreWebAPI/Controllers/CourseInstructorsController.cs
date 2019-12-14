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
    public class CourseInstructorsController : ControllerBase
    {
        private readonly ContosouniversityContext _context;

        public CourseInstructorsController(ContosouniversityContext context)
        {
            _context = context;
        }

        // GET: api/CourseInstructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseInstructor>>> GetCourseInstructor()
        {
            return await _context.CourseInstructor.ToListAsync();
        }
        /// <summary>
        /// 找出 CourseID == id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CourseInstructors/5
        [HttpGet("Course/{id}")]
        public async Task<ActionResult<IEnumerable<CourseInstructor>>> GetCourseInstructorByCourseID(int id)
        {
            var courseInstructor = await _context.CourseInstructor.Where(x => x.CourseId == id).ToListAsync();

            if (courseInstructor == null)
            {
                return NotFound();
            }

            return courseInstructor;
        }
        /// <summary>
        /// 找出 InstructorID == id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CourseInstructors/5
        [HttpGet("Instructor/{id}")]
        public async Task<ActionResult<IEnumerable<CourseInstructor>>> GetCourseInstructorByInstructorID(int id)
        {
            var courseInstructor = await _context.CourseInstructor.Where(x => x.InstructorId == id).ToListAsync();

            if (courseInstructor == null)
            {
                return NotFound();
            }

            return courseInstructor;
        }
        // PUT: api/CourseInstructors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        // TODO: 更新尚未實作
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCourseInstructor(int id, CourseInstructor courseInstructor)
        //{
        //    if (id != courseInstructor.CourseId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(courseInstructor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CourseInstructorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/CourseInstructors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CourseInstructor>> PostCourseInstructor(CourseInstructor courseInstructor)
        {
            _context.CourseInstructor.Add(courseInstructor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseInstructorExists(courseInstructor.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourseInstructor", new { id = courseInstructor.CourseId }, courseInstructor);
        }
        /// <summary>
        /// 刪除指定 courseId 及 instructorId
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="instructorId"></param>
        /// <returns></returns>
        // DELETE: api/CourseInstructors/
        [HttpDelete]
        public async Task<ActionResult<CourseInstructor>> DeleteCourseInstructor(int courseId, int instructorId)
        {
            var courseInstructor = await _context.CourseInstructor.Where(x => x.CourseId == courseId && x.InstructorId == instructorId).FirstAsync();
            if (courseInstructor == null)
            {
                return NotFound();
            }

            _context.CourseInstructor.Remove(courseInstructor);
            await _context.SaveChangesAsync();

            return courseInstructor;
        }

        private bool CourseInstructorExists(int id)
        {
            return _context.CourseInstructor.Any(e => e.CourseId == id);
        }
    }
}
