/*
 * By: voidotexe
 * https://www.github.com/voidotexe
 */

using System;
using System.Collections.Generic;

namespace EmailHistory.Repository
{
    public interface IDatabaseRepository
    {
        string ConnectionString { get; set; }

        void Insert(string from, string to, string subject, string body, DateTime when);

        void Truncate(string tableName);

        IEnumerable<T> SelectAll<T>();
    }
}
