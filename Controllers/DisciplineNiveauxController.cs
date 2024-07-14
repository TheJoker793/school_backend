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
    public class DisciplineNiveauxController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public DisciplineNiveauxController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/DisciplineNiveaux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisciplineNiveau>>> GetDisciplineNiveaux()
        {
            var ListDiscpNiveaux = await _context.DisciplineNiveaux.ToListAsync();
            var ListDto=_mapper.Map<List<DisciplineNiveauDto>>(ListDiscpNiveaux);
            return Ok(ListDto);
        }

        // GET: api/DisciplineNiveaux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisciplineNiveau>> GetDisciplineNiveau(int id)
        {
            var disciplineNiveau = await _context.DisciplineNiveaux.FindAsync(id);

            if (disciplineNiveau == null)
            {
                return NotFound();
            }

            return disciplineNiveau;
        }

        // PUT: api/DisciplineNiveaux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplineNiveau(int id, DisciplineNiveauDto disciplineNiveauDto)
        {
            var disciplineNiveau = _mapper.Map<DisciplineNiveau>(disciplineNiveauDto);
            if (id != disciplineNiveau.Id)
            {
                return BadRequest();
            }

            _context.Entry(disciplineNiveau).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineNiveauExists(id))
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

        // POST: api/DisciplineNiveaux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisciplineNiveau>> PostDisciplineNiveau(DisciplineNiveauDto disciplineNiveauDto)
        {
            var disciplineNiveau = _mapper.Map<DisciplineNiveau>(disciplineNiveauDto);

            _context.DisciplineNiveaux.Add(disciplineNiveau);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplineNiveau", new { id = disciplineNiveau.Id }, disciplineNiveau);
        }

        // DELETE: api/DisciplineNiveaux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplineNiveau(int id)
        {
            var disciplineNiveau = await _context.DisciplineNiveaux.FindAsync(id);
            if (disciplineNiveau == null)
            {
                return NotFound();
            }

            _context.DisciplineNiveaux.Remove(disciplineNiveau);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplineNiveauExists(int id)
        {
            return _context.DisciplineNiveaux.Any(e => e.Id == id);
        }
    }
}
