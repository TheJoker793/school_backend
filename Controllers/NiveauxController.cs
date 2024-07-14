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
    public class NiveauxController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public NiveauxController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Niveaux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Niveau>>> GetNiveaux()
        {
            var AllLevels= await _context.Niveaux.ToListAsync();
            return Ok(_mapper.Map<List<NiveauDto>>(AllLevels));
        }

        // GET: api/Niveaux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Niveau>> GetNiveau(int id)
        {
            var niveau = await _context.Niveaux.FindAsync(id);

            if (niveau == null)
            {
                return NotFound();
            }

            return niveau;
        }

        // PUT: api/Niveaux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNiveau(int id, NiveauDto niveauDto)
        {
            var niveau = _mapper.Map<Niveau>(niveauDto);

            if (id != niveau.Id)
            {
                return BadRequest();
            }

            _context.Entry(niveau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NiveauExists(id))
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

        // POST: api/Niveaux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Niveau>> PostNiveau(NiveauDto niveauDto)
        {
            var niveau = _mapper.Map<Niveau>(niveauDto);

            _context.Niveaux.Add(niveau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNiveau", new { id = niveau.Id }, niveau);
        }

        // DELETE: api/Niveaux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNiveau(int id)
        {
            var niveau = await _context.Niveaux.FindAsync(id);
            if (niveau == null)
            {
                return NotFound();
            }

            _context.Niveaux.Remove(niveau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NiveauExists(int id)
        {
            return _context.Niveaux.Any(e => e.Id == id);
        }
    }
}
