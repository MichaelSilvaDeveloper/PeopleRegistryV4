using DadosInfra.Map;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosInfra.Configuration
{
    public class PeopleRegistryDBContext : DbContext
    {
        public PeopleRegistryDBContext(DbContextOptions<PeopleRegistryDBContext> options) : base(options)
        {
        }

        public DbSet<Person> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}