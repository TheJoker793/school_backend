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
    public class MatieresController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public MatieresController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Matieres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matiere>>> GetMatieres()
        {
            var AllMatieres= await _context.Matieres.ToListAsync();
            return Ok(_mapper.Map<List<MatiereDto>>(AllMatieres));
        }

        // GET: api/Matieres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Matiere>> GetMatiere(int id)
        {
            var matiere = await _context.Matieres.FindAsync(id);

            if (matiere == null)
            {
                return NotFound();
            }

            return matiere;
        }

        // PUT: api/Matieres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatiere(int id, MatiereDto matiereDto)
        {
            var matiere = _mapper.Map<Matiere>(matiereDto);
            if (id != matiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(matiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatiereExists(id))
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

        // POST: api/Matieres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Matiere>> PostMatiere(MatiereDto matiereDto)
        {
            var matiere = _mapper.Map<Matiere>(matiereDto);

            _context.Matieres.Add(matiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatiere", new { id = matiere.Id }, matiere);
        }

        // DELETE: api/Matieres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatiere(int id)
        {
            var matiere = await _context.Matieres.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }

            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MatiereExists(int id)
        {
            return _context.Matieres.Any(e => e.Id == id);
        }
    }
}
