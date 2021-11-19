﻿using Apocrypha.CommonObject.Models;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.EntityFramework
{
    /// <summary>
    /// Represents the database context.
    /// Add migration from root folder:
    ///     dotnet ef migrations add [NAME] --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF
    ///     dotnet ef database upgrade --project Apocrypha.EntityFramework --startup-project Apocrypha.WPF
    /// </summary>
    public class ApocryphaDbContext : DbContext
    {
        #region DatabaseTables

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        public ApocryphaDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}