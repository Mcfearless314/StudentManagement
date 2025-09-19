using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Database;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration on Student entity
        modelBuilder.Entity<Student>(ent =>
        {
            ent.HasKey(s => s.Id);

            ent.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            ent.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            ent.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(40);

            ent.Property(s => s.EnrollmentDate)
                .IsRequired();
        });
        
        // Configuration on Course entity
        modelBuilder.Entity<Course>(ent =>
        {
            ent.HasKey(c => c.CourseId);
            
            ent.Property(c => c.CourseId)
                .ValueGeneratedOnAdd();

            ent.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            ent.Property(c => c.Credits)
                .IsRequired();
        });
        
        // Configuration on Enrollment entity
        modelBuilder.Entity<Enrollment>(ent =>
        {
            ent.HasKey(e => e.Id);
            
            ent.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            ent.Property(e => e.Grade)
                .HasMaxLength(2);

            ent.HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            ent.HasOne<Course>()
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}