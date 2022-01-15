/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using EmailHistory.Models;
using EmailHistory.Repository;
using System.Collections.Generic;
using System;

namespace EmailHistory.Services
{
    public class EmailService
    {
        private readonly IDatabaseRepository _database;
        public List<Email> Emails { get; set;} = new List<Email>();

        public EmailService()
        {
            _database = new DatabaseRepository();
        }

        public EmailService(IDatabaseRepository database)
        {
            _database = database;
        }

        public bool Create(string from, string to, string subject, string body, DateTime when)
        {
            try
            {
                _database.Insert(from, to, subject, body, when);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public List<Email> GetAll()
        {
            Emails.Clear();

            foreach (var row in _database.SelectAll<Email>())
            {
                Emails.Add(row);
            }

            return Emails;
        }

        public void DeleteAll()
        {
            _database.Truncate("Mails");

            Emails.Clear();
        }
    }
}
