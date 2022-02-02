/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using EmailHistory.Models;

namespace EmailHistory.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailHistory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Insert(string from, string to, string subject, string body, DateTime when)
        {
            try
            {
                using SqlConnection Connection = new SqlConnection(ConnectionString);

                string query = "INSERT INTO Mails ([From], [To], [Subject], [Body], [When]) VALUES (@From, @To, @Subject, @Body, @When)";
                var parameters = new { From = from, To = to, Subject = subject, Body = body, When = when };

                Connection.Execute(query, parameters);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Email> SelectAll()
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            
            string query = "SELECT * FROM Mails";

            return Connection.Query<Email>(query);
        }

        public void Truncate()
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);

            Connection.Execute($"TRUNCATE TABLE Mails");
        }
    }
}
