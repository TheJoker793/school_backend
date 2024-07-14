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
    public class AnneeScolairesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public AnneeScolairesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/AnneeScolaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnneeScolaire>>> GetAnneeScolaires()
        {
            var AllYears= await _context.AnneeScolaires.ToListAsync();            
            return Ok(_mapper.Map<List<AnneeScolaireDto>>(AllYears));
        }

        // GET: api/AnneeScolaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnneeScolaire>> GetAnneeScolaire(int id)
        {
            var anneeScolaire = await _context.AnneeScolaires.FindAsync(id);

            if (anneeScolaire == null)
            {
                return NotFound();
            }

            return anneeScolaire;
        }

        // PUT: api/AnneeScolaires/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnneeScolaire(int id, AnneeScolaireDto anneeScolaireDto)
        {
            var anneeScolaire = _mapper.Map<AnneeScolaire>(anneeScolaireDto);

            if (id != anneeScolaire.Id)
            {
                return BadRequest();
            }

            _context.Entry(anneeScolaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnneeScolaireExists(id))
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

        // POST: api/AnneeScolaires
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnneeScolaire>> PostAnneeScolaire(AnneeScolaireDto anneeScolaireDto)
        {
            var anneeScolaire = _mapper.Map<AnneeScolaire>(anneeScolaireDto);
            _context.AnneeScolaires.Add(anneeScolaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnneeScolaire", new { id = anneeScolaire.Id }, anneeScolaire);
        }

        // DELETE: api/AnneeScolaires/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnneeScolaire(int id)
        {
            var anneeScolaire = await _context.AnneeScolaires.FindAsync(id);
            if (anneeScolaire == null)
            {
                return NotFound();
            }

            _context.AnneeScolaires.Remove(anneeScolaire);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnneeScolaireExists(int id)
        {
            return _context.AnneeScolaires.Any(e => e.Id == id);
        }
    }
}
