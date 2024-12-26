using Microsoft.EntityFrameworkCore;
using LearningPlatform.Models;

namespace LearningPlatform.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data (optional) if you want initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User {
                    Id = 1,
                    Username = "User",
                    Email = "user@example.com",
                    PasswordHash = "$2a$11$1Vlw8tH0pHps2RBSvLg8R.2tpykfbLvxHuKvcCXlwy8PC3yUgdqiW",
                }
            );
            // Example: Add initial courses or achievements
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Language = "English",
                    Level = "Beginner",
                    Description = "Learn basic English communication skills."
                },
                new Course
                {
                    Id = 2,
                    Language = "Spanish",
                    Level = "Intermediate",
                    Description = "Enhance your Spanish fluency."
                }
            );
        }
    }
}
