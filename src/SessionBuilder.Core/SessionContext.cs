using System;
using Microsoft.EntityFrameworkCore;

namespace SessionBuilder.Core
{
    public class SessionContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source='sesson.db'");
        }

    }
}
