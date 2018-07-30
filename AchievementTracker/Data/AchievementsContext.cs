using System;
using AchievementTracker.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace AchievementTracker.Data
{
    public class AchievementsContext : DbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        private string _databasePath;

        public AchievementsContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
