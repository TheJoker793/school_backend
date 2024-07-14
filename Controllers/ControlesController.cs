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
    public class ControlesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public ControlesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Controles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Controle>>> GetControles()
        {
            var AllControles = await _context.Controles.ToListAsync();
            return Ok(_mapper.Map<List<ControleDto>>(AllControles));
        }

        // GET: api/Controles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Controle>> GetControle(int id)
        {
            var controle = await _context.Controles.FindAsync(id);

            if (controle == null)
            {
                return NotFound();
            }

            return controle;
        }

        // PUT: api/Controles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControle(int id, ControleDto controleDto)
        {
            var controle = _mapper.Map<Controle>(controleDto);
            if (id != controle.Id)
            {
                return BadRequest();
            }

            _context.Entry(controle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControleExists(id))
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

        // POST: api/Controles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Controle>> PostControle(ControleDto controleDto)
        {
            var controle = _mapper.Map<Controle>(controleDto);

            _context.Controles.Add(controle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetControle", new { id = controle.Id }, controle);
        }

        // DELETE: api/Controles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControle(int id)
        {
            var controle = await _context.Controles.FindAsync(id);
            if (controle == null)
            {
                return NotFound();
            }

            _context.Controles.Remove(controle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ControleExists(int id)
        {
            return _context.Controles.Any(e => e.Id == id);
        }
    }
}
