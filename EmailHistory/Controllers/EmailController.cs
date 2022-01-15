/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using Microsoft.AspNetCore.Mvc;
using EmailHistory.Services;
using System;

namespace EmailHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService = new EmailService();
        
        // GET: api/email/get
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_emailService.GetAll());
        }

        // POST api/email/create
        [HttpPost("[action]")]
        public IActionResult Create(string from, string to, string subject, string body, DateTime when)
        {
            if (_emailService.Create(from, to, subject, body, when))
                return NoContent();

            return StatusCode(500);
        }

        // DELETE api/email/delete
        [HttpDelete("[action]")]
        public IActionResult Delete()
        {
            _emailService.DeleteAll();

            return NoContent();
        }
    }
}
