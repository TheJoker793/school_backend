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
    public class ProfesseursController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;


        public ProfesseursController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Professeurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professeur>>> GetProfesseurs()
        {
            var AllProfessors= await _context.Professeurs.ToListAsync();
            return Ok(_mapper.Map<List<ProfesseurDto>>(AllProfessors));
        }

        // GET: api/Professeurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professeur>> GetProfesseur(int id)
        {
            var professeur = await _context.Professeurs.FindAsync(id);

            if (professeur == null)
            {
                return NotFound();
            }

            return professeur;
        }

        // PUT: api/Professeurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesseur(int id, ProfesseurDto professeurDto)
        {
            var professeur = _mapper.Map<Professeur>(professeurDto);
            if (id != professeur.Id)
            {
                return BadRequest();
            }

            _context.Entry(professeur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesseurExists(id))
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

        // POST: api/Professeurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Professeur>> PostProfesseur(ProfesseurDto professeurDto)
        {
            var professeur = _mapper.Map<Professeur>(professeurDto);

            _context.Professeurs.Add(professeur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesseur", new { id = professeur.Id }, professeur);
        }

        // DELETE: api/Professeurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesseur(int id)
        {
            var professeur = await _context.Professeurs.FindAsync(id);
            if (professeur == null)
            {
                return NotFound();
            }

            _context.Professeurs.Remove(professeur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesseurExists(int id)
        {
            return _context.Professeurs.Any(e => e.Id == id);
        }
    }
}
