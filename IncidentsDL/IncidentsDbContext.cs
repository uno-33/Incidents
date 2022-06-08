using IncidentsDL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentsDL
{
    public class IncidentsDbContext : DbContext
    {
        public IncidentsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

    }
}
