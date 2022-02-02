/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using System;
using System.Collections.Generic;
using EmailHistory.Models;

namespace EmailHistory.Repository
{
    public interface IDatabaseRepository
    {
        string ConnectionString { get; set; }

        bool Insert(string from, string to, string subject, string body, DateTime when);

        void Truncate();

        IEnumerable<Email> SelectAll();
    }
}
