using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Backend.DTOs;
using School_Backend.Models;

namespace School_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentStudentsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public ParentStudentsController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ParentStudents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParentStudent>>> GetParentsStudents()
        {
            var AllParentlies= await _context.ParentsStudents.ToListAsync();
            return Ok(_mapper.Map<List<ParentStudentDto>>(AllParentlies));
        }

        // GET: api/ParentStudents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParentStudent>> GetParentStudent(int id)
        {
            var parentStudent = await _context.ParentsStudents.FindAsync(id);

            if (parentStudent == null)
            {
                return NotFound();
            }

            return parentStudent;
        }

        // PUT: api/ParentStudents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParentStudent(int id, ParentStudentDto parentStudentDto)
        {
            var ParentStudent = _mapper.Map<ParentStudent>(parentStudentDto);
            if (id != ParentStudent.Id)
            {
                return BadRequest();
            }

            _context.Entry(ParentStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentStudentExists(id))
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

        // POST: api/ParentStudents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParentStudent>> PostParentStudent(ParentStudentDto parentStudentDto)
        {
            var newParenty=_mapper.Map<ParentStudent>(parentStudentDto);
            _context.ParentsStudents.Add(newParenty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParentStudent", new { id = newParenty.Id }, newParenty);
        }

        // DELETE: api/ParentStudents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParentStudent(int id)
        {
            var parentStudent = await _context.ParentsStudents.FindAsync(id);
            if (parentStudent == null)
            {
                return NotFound();
            }

            _context.ParentsStudents.Remove(parentStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentStudentExists(int id)
        {
            return _context.ParentsStudents.Any(e => e.Id == id);
        }
    }
}
