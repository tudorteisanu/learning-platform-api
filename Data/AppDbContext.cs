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
        public DbSet<Option> Options { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<LessonContent> LessonContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - Unique Email Constraint
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Course - Lesson Relationship
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            // Lesson - Question Relationship
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Questions)
                .WithOne(q => q.Lesson)
                .HasForeignKey(q => q.LessonId);

            // Question - Option Relationship
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId);

            // User - UserProgress Relationship
            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.User)
                .WithMany(u => u.Progress)
                .HasForeignKey(up => up.UserId);

            // Lesson - UserProgress Relationship
            modelBuilder.Entity<UserProgress>()
                .HasOne(up => up.Lesson)
                .WithMany()
                .HasForeignKey(up => up.LessonId);

            // User - Achievement Relationship
            modelBuilder.Entity<UserAchievement>()
                .HasOne(ua => ua.User)
                .WithMany()
                .HasForeignKey(ua => ua.UserId);

            // modelBuilder.Entity<UserAchievement>()
            //     .HasOne(ua => ua.Achievement)
            //     .WithMany()
            //     .HasForeignKey("AchievementId");

            // Seed Data (optional) if you want initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Example: Add initial courses or achievements
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Language = "English",
                    Level = "Beginner",
                    Description = "Learn basic English communication skills."
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Language = "Spanish",
                    Level = "Intermediate",
                    Description = "Enhance your Spanish fluency."
                }
            );
        }
    }
}
