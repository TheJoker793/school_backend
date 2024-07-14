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
    public class StudentControlesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public StudentControlesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StudentControles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentControle>>> GetStudentControles()
        {
            var all= await _context.StudentControles.ToListAsync();
            return Ok(_mapper.Map<List<ControleStudentDto>>(all));
        }

        // GET: api/StudentControles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentControle>> GetStudentControle(int id)
        {
            var studentControle = await _context.StudentControles.FindAsync(id);

            if (studentControle == null)
            {
                return NotFound();
            }

            return studentControle;
        }

        // PUT: api/StudentControles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentControle(int id, StudentControle studentControle)
        {
            if (id != studentControle.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentControle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentControleExists(id))
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

        // POST: api/StudentControles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentControle>> PostStudentControle(ControleStudentDto studentControleDto)
        {
            var studentControle = _mapper.Map<StudentControle>(studentControleDto);
            _context.StudentControles.Add(studentControle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentControle", new { id = studentControle.Id }, studentControle);
        }

        // DELETE: api/StudentControles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentControle(int id)
        {
            var studentControle = await _context.StudentControles.FindAsync(id);
            if (studentControle == null)
            {
                return NotFound();
            }

            _context.StudentControles.Remove(studentControle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentControleExists(int id)
        {
            return _context.StudentControles.Any(e => e.Id == id);
        }
    }
}
