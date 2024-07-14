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

namespace Backend_School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReglementsController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public ReglementsController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Reglements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reglement>>> GetReglements()
        {
            var ListReglements= await _context.Reglements.ToListAsync();
            return Ok(_mapper.Map<List<ReglementDto>>(ListReglements));
        }

        // GET: api/Reglements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reglement>> GetReglement(int id)
        {
            var reglement = await _context.Reglements.FindAsync(id);

            if (reglement == null)
            {
                return NotFound();
            }

            return reglement;
        }

        // PUT: api/Reglements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReglement(int id, ReglementDto reglementDto)
        {
            var reglement = _mapper.Map<Reglement>(reglementDto);
            if (id != reglement.Id)
            {
                return BadRequest();
            }

            _context.Entry(reglement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReglementExists(id))
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

        // POST: api/Reglements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reglement>> PostReglement(ReglementDto reglementDto)
        {
            var reglement = _mapper.Map<Reglement>(reglementDto);
            _context.Reglements.Add(reglement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReglement", new { id = reglement.Id }, reglement);
        }

        // DELETE: api/Reglements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReglement(int id)
        {
            var reglement = await _context.Reglements.FindAsync(id);
            if (reglement == null)
            {
                return NotFound();
            }

            _context.Reglements.Remove(reglement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReglementExists(int id)
        {
            return _context.Reglements.Any(e => e.Id == id);
        }
    }
}
