using System;
using System.ComponentModel.DataAnnotations;

namespace AchievementTracker.Models.Data
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
