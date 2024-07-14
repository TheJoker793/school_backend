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
    public class AssiduitesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public AssiduitesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Assiduites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assiduite>>> GetAssiduites()
        {
            var AllAssiduites= await _context.Assiduites.ToListAsync();
            return Ok(_mapper.Map<List<AssiduiteDto>>(AllAssiduites));
        }

        // GET: api/Assiduites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assiduite>> GetAssiduite(int id)
        {
            var assiduite = await _context.Assiduites.FindAsync(id);

            if (assiduite == null)
            {
                return NotFound();
            }

            return assiduite;
        }

        // PUT: api/Assiduites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssiduite(int id, AssiduiteDto assiduiteDto)
        {
            var AssiduiteUpdate = _mapper.Map<Assiduite>(assiduiteDto);
            if (id != AssiduiteUpdate.Id)
            {
                return BadRequest();
            }

            _context.Entry(AssiduiteUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssiduiteExists(id))
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

        // POST: api/Assiduites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assiduite>> PostAssiduite(AssiduiteDto assiduiteDto)
        {
            var NewAssiduite = _mapper.Map<Assiduite>(assiduiteDto);

            _context.Assiduites.Add(NewAssiduite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssiduite", new { id = NewAssiduite.Id }, NewAssiduite);
        }

        // DELETE: api/Assiduites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssiduite(int id)
        {
            var assiduite = await _context.Assiduites.FindAsync(id);
            if (assiduite == null)
            {
                return NotFound();
            }

            _context.Assiduites.Remove(assiduite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssiduiteExists(int id)
        {
            return _context.Assiduites.Any(e => e.Id == id);
        }
    }
}
