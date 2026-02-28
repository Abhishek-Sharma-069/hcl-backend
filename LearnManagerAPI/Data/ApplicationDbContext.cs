using Microsoft.EntityFrameworkCore;
using LearnManagerAPI.Models;

namespace LearnManagerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Progress> Progresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configuration – map to existing PostgreSQL table "users" (snake_case columns)
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.Property(u => u.Id).HasColumnName("id");
                e.Property(u => u.Name).HasColumnName("name");
                e.Property(u => u.Email).HasColumnName("email");
                e.Property(u => u.PasswordHash).HasColumnName("password_hash");
                e.Property(u => u.Role).HasColumnName("role");
                e.Property(u => u.CreatedAt).HasColumnName("created_at");
                e.HasIndex(u => u.Email).IsUnique();
            });

            // Course configuration – map to existing PostgreSQL table "courses" (snake_case columns)
            modelBuilder.Entity<Course>(e =>
            {
                e.ToTable("courses");
                e.Property(c => c.Id).HasColumnName("id");
                e.Property(c => c.Title).HasColumnName("title");
                e.Property(c => c.Description).HasColumnName("description");
                e.Property(c => c.InstructorId).HasColumnName("instructor_id");
                e.Property(c => c.CreatedAt).HasColumnName("created_at");
                e.HasOne(c => c.Instructor)
                    .WithMany()
                    .HasForeignKey(c => c.InstructorId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Lesson configuration
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Quiz configuration
            modelBuilder.Entity<Quiz>()
                .HasOne(q => q.Course)
                .WithMany(c => c.Quizzes)
                .HasForeignKey(q => q.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            // QuizQuestion configuration
            modelBuilder.Entity<QuizQuestion>()
                .HasOne(qq => qq.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(qq => qq.QuizId)
                .OnDelete(DeleteBehavior.SetNull);

            // Enrollment configuration
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            // Progress configuration
            modelBuilder.Entity<Progress>()
                .HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Progress>()
                .HasOne(p => p.Lesson)
                .WithMany()
                .HasForeignKey(p => p.LessonId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Progress>()
                .HasOne(p => p.Quiz)
                .WithMany()
                .HasForeignKey(p => p.QuizId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
