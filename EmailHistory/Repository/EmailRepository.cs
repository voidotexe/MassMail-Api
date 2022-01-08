using EmailHistory.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;

namespace EmailHistory.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;
        public List<Email> Emails { get; set;} = new List<Email>();

        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Create(string from, string to, string subject, string body, DateTime when)
        {
            try
            {
                using SqlConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                string insertSql = "INSERT INTO Mails ([From], [To], [Subject], [Body], [When]) VALUES (@From, @To, @Subject, @Body, @When)";
                var insertParameters = new { From = from, To = to, Subject = subject, Body = body, When = when };

                db.Execute(insertSql, insertParameters);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public List<Email> GetAll()
        {
            using (SqlConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                Emails.Clear();

                foreach (var row in db.Query<Email>("SELECT * FROM Mails"))
                {
                    Emails.Add(row);
                }

                return Emails;
            }
        }

        public void DeleteAll()
        {
            using SqlConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            db.Execute("TRUNCATE TABLE Mails");

            Emails.Clear();
        }
    }
}
