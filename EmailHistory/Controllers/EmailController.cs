using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmailHistory.Repository;
using EmailHistory.Models;
using System;

namespace EmailHistory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        // GET: api/email/get        
        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(_emailRepository.GetAll());
        }

        // POST api/email/create
        [HttpPost("[action]")]
        public IActionResult Create(string from, string to, string subject, string body, DateTime when)
        {
            if (_emailRepository.Create(from, to, subject, body, when))
            {
                return NoContent();
            }

            return StatusCode(500);
        }

        // DELETE api/email/delete
        [HttpDelete("[action]")]
        public IActionResult Delete()
        {
            _emailRepository.DeleteAll();

            return NoContent();
        }
    }
}
