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
    public class SallesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public SallesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Salles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salle>>> GetSalles()
        {
            var AllSalles= await _context.Salles.ToListAsync();
            return Ok(_mapper.Map<List<SalleDto>>(AllSalles));
        }

        // GET: api/Salles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salle>> GetSalle(int id)
        {
            var salle = await _context.Salles.FindAsync(id);

            if (salle == null)
            {
                return NotFound();
            }

            return salle;
        }

        // PUT: api/Salles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalle(int id, SalleDto salleDto)
        {
            var salle = _mapper.Map<Salle>(salleDto);
            if (id != salle.Id)
            {
                return BadRequest();
            }

            _context.Entry(salle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalleExists(id))
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

        // POST: api/Salles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salle>> PostSalle(SalleDto salleDto)
        {
            var salle = _mapper.Map<Salle>(salleDto);

            _context.Salles.Add(salle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalle", new { id = salle.Id }, salle);
        }

        // DELETE: api/Salles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalle(int id)
        {
            var salle = await _context.Salles.FindAsync(id);
            if (salle == null)
            {
                return NotFound();
            }

            _context.Salles.Remove(salle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalleExists(int id)
        {
            return _context.Salles.Any(e => e.Id == id);
        }
    }
}
