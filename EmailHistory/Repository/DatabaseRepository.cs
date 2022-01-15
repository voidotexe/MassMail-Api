/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;

namespace EmailHistory.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public string ConnectionString { get; set; } = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailHistory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Insert(string from, string to, string subject, string body, DateTime when)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);

            string query = "INSERT INTO Mails ([From], [To], [Subject], [Body], [When]) VALUES (@From, @To, @Subject, @Body, @When)";
            var parameters = new { From = from, To = to, Subject = subject, Body = body, When = when };

            Connection.Execute(query, parameters);
        }

        public IEnumerable<T> SelectAll<T>()
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);
            
            string query = "SELECT * FROM Mails";

            return Connection.Query<T>(query);
        }

        public void Truncate(string tableName)
        {
            using SqlConnection Connection = new SqlConnection(ConnectionString);

            Connection.Execute($"TRUNCATE TABLE {tableName}");
        }
    }
}
