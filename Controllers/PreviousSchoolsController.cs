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
    public class PreviousSchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public PreviousSchoolsController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PreviousSchools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreviousSchool>>> GetPreviousSchools()
        {
            var ListPreviousSchool= await _context.PreviousSchools.ToListAsync();
            return Ok(_mapper.Map<List<PreviosSchoolDto>>(ListPreviousSchool));
        }

        // GET: api/PreviousSchools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreviousSchool>> GetPreviousSchool(int id)
        {
            var previousSchool = await _context.PreviousSchools.FindAsync(id);

            if (previousSchool == null)
            {
                return NotFound();
            }

            return previousSchool;
        }

        // PUT: api/PreviousSchools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreviousSchool(int id, PreviousSchool previousSchool)
        {
            if (id != previousSchool.Id)
            {
                return BadRequest();
            }

            _context.Entry(previousSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreviousSchoolExists(id))
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

        // POST: api/PreviousSchools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreviousSchool>> PostPreviousSchool(PreviosSchoolDto previousSchool)
        {
            var newPreviousSchool=_mapper.Map<PreviousSchool>(previousSchool);
            _context.PreviousSchools.Add(newPreviousSchool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreviousSchool", new { id = newPreviousSchool.Id }, newPreviousSchool);
        }

        // DELETE: api/PreviousSchools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreviousSchool(int id)
        {
            var previousSchool = await _context.PreviousSchools.FindAsync(id);
            if (previousSchool == null)
            {
                return NotFound();
            }

            _context.PreviousSchools.Remove(previousSchool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreviousSchoolExists(int id)
        {
            return _context.PreviousSchools.Any(e => e.Id == id);
        }
    }
}
