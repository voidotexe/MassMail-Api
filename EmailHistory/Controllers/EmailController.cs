/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using Microsoft.AspNetCore.Mvc;
using EmailHistory.Repository;
using EmailHistory.Models;
using System;

namespace EmailHistory.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IDatabaseRepository _databaseRepository;

        public EmailController(IDatabaseRepository databaseRepository)
        {
            _databaseRepository = databaseRepository;
        }

        // GET: email/get
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_databaseRepository.SelectAll());
        }

        // POST email/create
        [HttpPost]
        public IActionResult Create(string from, string to, string subject, string body, DateTime when)
        {
            if (_databaseRepository.Insert(from, to, subject, body, when))
                return NoContent();

            return StatusCode(500);
        }

        // DELETE email/delete
        [HttpDelete]
        public IActionResult Delete()
        {
            _databaseRepository.Truncate();

            return NoContent();
        }
    }
}
