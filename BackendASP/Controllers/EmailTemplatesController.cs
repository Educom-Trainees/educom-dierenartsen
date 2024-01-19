using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendASP.Database;
using BackendASP.Models;
using Microsoft.AspNetCore.Authorization;

namespace BackendASP.Controllers
{
    [Route("api/email-templates")]
    [ApiController]
    public class EmailTemplatesController : ControllerBase
    {
        private readonly PetCareContext _context;

        public EmailTemplatesController(PetCareContext context)
        {
            _context = context;
        }

        // GET: api/EmailTemplates
        [HttpGet]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public async Task<ActionResult<IEnumerable<EmailTemplate>>> GetEmailTemplates()
        {
          if (_context.EmailTemplates == null)
          {
              return NotFound();
          }
            return await _context.EmailTemplates.ToListAsync();
        }

        // GET: api/EmailTemplates/5
        [HttpGet("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public async Task<ActionResult<EmailTemplate>> GetEmailTemplate(int id)
        {
          if (_context.EmailTemplates == null)
          {
              return NotFound();
          }
            var emailTemplate = await _context.EmailTemplates.FindAsync(id);

            if (emailTemplate == null)
            {
                return NotFound();
            }

            return emailTemplate;
        }

        // PUT: api/EmailTemplates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public async Task<IActionResult> PutEmailTemplate(int id, EmailTemplate emailTemplate)
        {
            if (id != emailTemplate.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailTemplate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailTemplateExists(id))
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

        // POST: api/EmailTemplates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public async Task<ActionResult<EmailTemplate>> PostEmailTemplate(EmailTemplate emailTemplate)
        {
          if (_context.EmailTemplates == null)
          {
              return Problem("Entity set 'PetCareContext.EmailTemplates'  is null.");
          }
            _context.EmailTemplates.Add(emailTemplate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailTemplate", new { id = emailTemplate.Id }, emailTemplate);
        }

        // DELETE: api/EmailTemplates/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "EMPLOYEE, ADMIN")]
        public async Task<IActionResult> DeleteEmailTemplate(int id)
        {
            if (_context.EmailTemplates == null)
            {
                return NotFound();
            }
            var emailTemplate = await _context.EmailTemplates.FindAsync(id);
            if (emailTemplate == null)
            {
                return NotFound();
            }

            _context.EmailTemplates.Remove(emailTemplate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailTemplateExists(int id)
        {
            return (_context.EmailTemplates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
