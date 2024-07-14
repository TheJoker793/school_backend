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
    public class FraisController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public FraisController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Frais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frais>>> GetFraiss()
        {
            var ListFrais = await _context.Fraiss.ToListAsync();
            return Ok(_mapper.Map<List<FraisDto>>(ListFrais));
        }

        // GET: api/Frais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frais>> GetFrais(int id)
        {
            var frais = await _context.Fraiss.FindAsync(id);

            if (frais == null)
            {
                return NotFound();
            }

            return frais;
        }

        // PUT: api/Frais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrais(int id, Frais frais)
        {
            if (id != frais.Id)
            {
                return BadRequest();
            }

            _context.Entry(frais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FraisExists(id))
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

        // POST: api/Frais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Frais>> PostFrais(Frais frais)
        {
            _context.Fraiss.Add(frais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFrais", new { id = frais.Id }, frais);
        }

        // DELETE: api/Frais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrais(int id)
        {
            var frais = await _context.Fraiss.FindAsync(id);
            if (frais == null)
            {
                return NotFound();
            }

            _context.Fraiss.Remove(frais);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FraisExists(int id)
        {
            return _context.Fraiss.Any(e => e.Id == id);
        }
    }
}
