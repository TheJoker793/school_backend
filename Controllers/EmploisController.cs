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
    public class EmploisController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public EmploisController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Emplois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploi>>> GetEmplois()
        {
            var AllEmplois= await _context.Emplois.ToListAsync();
            return Ok(_mapper.Map<List<EmploiDto>>(AllEmplois));
        }

        // GET: api/Emplois/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emploi>> GetEmploi(int id)
        {
            var emploi = await _context.Emplois.FindAsync(id);

            if (emploi == null)
            {
                return NotFound();
            }

            return emploi;
        }

        // PUT: api/Emplois/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploi(int id, EmploiDto emploiDto)
        {
            var emploi = _mapper.Map<Emploi>(emploiDto);
            if (id != emploi.Id)
            {
                return BadRequest();
            }

            _context.Entry(emploi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploiExists(id))
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

        // POST: api/Emplois
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emploi>> PostEmploi(EmploiDto emploiDto)
        {
            var emploi = _mapper.Map<Emploi>(emploiDto);

            _context.Emplois.Add(emploi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploi", new { id = emploi.Id }, emploi);
        }

        // DELETE: api/Emplois/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploi(int id)
        {
            var emploi = await _context.Emplois.FindAsync(id);
            if (emploi == null)
            {
                return NotFound();
            }

            _context.Emplois.Remove(emploi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploiExists(int id)
        {
            return _context.Emplois.Any(e => e.Id == id);
        }
    }
}
