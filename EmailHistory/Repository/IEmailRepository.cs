using System.Collections.Generic;
using EmailHistory.Models;
using System;

namespace EmailHistory.Repository
{
    public interface IEmailRepository
    {
        public List<Email> Emails { get; set; }

        bool Create(string from, string to, string subject, string body, DateTime when);
        List<Email> GetAll();
        void DeleteAll();

    }
}
