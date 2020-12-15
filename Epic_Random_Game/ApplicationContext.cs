using Epic_Random_Game.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epic_Random_Game
{
    class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder
           optionsBuilder)
        {
            string connectionStringBuilder = new
               SqliteConnectionStringBuilder()
            {
                DataSource = "RandomGamedb.db"
            }
            .ToString();

            var connection = new SqliteConnection(connectionStringBuilder);
            optionsBuilder.UseSqlite(connection);
        }
       
    }
}
