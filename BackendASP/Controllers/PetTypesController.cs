﻿using AutoMapper;
using BackendASP.Database;
using BackendASP.Models;
using BackendASP.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendASP.Controllers
{
    [Route("pet-types")]
    [ApiController]
    public class PetTypesController : ControllerBase
    {
        private readonly PetCareContext _context;
        private readonly IMapper _mapper;

        public PetTypesController(PetCareContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/PetTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetTypeDTO>>> GetPetTypes()
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petTypes = await _mapper.ProjectTo<PetTypeDTO>(_context.PetTypes)
                .ToListAsync();

            return petTypes;
        }

        // GET: api/PetTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetTypeDTO>> GetPetTypeById(int id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petType = await _mapper.ProjectTo<PetTypeDTO>(_context.PetTypes)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (petType == null)
            {
                return NotFound();
            }

            return petType;
        }

        // PUT: api/PetTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetType(int id, PetType petType)
        {
            if (id != petType.Id)
            {
                return BadRequest();
            }

            _context.Entry(petType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetTypeExists(id))
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

        // POST: api/PetTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PetType>> PostPetType(PetType petType)
        {
            if (_context.PetTypes == null)
            {
                return Problem("Entity set 'PetCareContext.PetTypes'  is null.");
            }
            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPetType", new { id = petType.Id }, petType);
        }

        // DELETE: api/PetTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetType(int id)
        {
            if (_context.PetTypes == null)
            {
                return NotFound();
            }
            var petType = await _context.PetTypes.FindAsync(id);
            if (petType == null)
            {
                return NotFound();
            }

            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetTypeExists(int id)
        {
            return (_context.PetTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
