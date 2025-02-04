﻿using System;
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
    public class ClassesController : ControllerBase
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public ClassesController(SchoolDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Classe>>> GetClasses()
        {
            var AllClasses= await _context.Classes.ToListAsync();
            return Ok(_mapper.Map<List<ClasseDto>>(AllClasses));
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classe>> GetClasse(int id)
        {
            var classe = await _context.Classes.FindAsync(id);

            if (classe == null)
            {
                return NotFound();
            }

            return classe;
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasse(int id, ClasseDto classeDto)
        {
            var classe = _mapper.Map<Classe>(classeDto);
            if (id != classe.Id)
            {
                return BadRequest();
            }

            _context.Entry(classe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasseExists(id))
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

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Classe>> PostClasse(ClasseDto classeDto)
        {
            var classe = _mapper.Map<Classe>(classeDto);

            _context.Classes.Add(classe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasse", new { id = classe.Id }, classe);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasse(int id)
        {
            var classe = await _context.Classes.FindAsync(id);
            if (classe == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasseExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
