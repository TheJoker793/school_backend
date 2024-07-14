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
    public class DiplomesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public DiplomesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Diplomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diplome>>> GetDiplomes()
        {
            var AllDiplomes= await _context.Diplomes.ToListAsync();
            return Ok(_mapper.Map<List<DiplomeDto>>(AllDiplomes));
        }

        // GET: api/Diplomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diplome>> GetDiplome(int id)
        {
            var diplome = await _context.Diplomes.FindAsync(id);

            if (diplome == null)
            {
                return NotFound();
            }

            return diplome;
        }

        // PUT: api/Diplomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiplome(int id, DiplomeDto diplomeDto)
        {
            var diplome = _mapper.Map<Diplome>(diplomeDto);
            if (id != diplome.Id)
            {
                return BadRequest();
            }

            _context.Entry(diplome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomeExists(id))
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

        // POST: api/Diplomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diplome>> PostDiplome(DiplomeDto diplomeDto)
        {
            var diplome = _mapper.Map<Diplome>(diplomeDto);

            _context.Diplomes.Add(diplome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiplome", new { id = diplome.Id }, diplome);
        }

        // DELETE: api/Diplomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiplome(int id)
        {
            var diplome = await _context.Diplomes.FindAsync(id);
            if (diplome == null)
            {
                return NotFound();
            }

            _context.Diplomes.Remove(diplome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiplomeExists(int id)
        {
            return _context.Diplomes.Any(e => e.Id == id);
        }
    }
}
