using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuration for Student entity
        modelBuilder.Entity<Student>(ent =>
        {
            ent.HasKey(s => s.Id);

            ent.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            ent.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            ent.Property(s => s.MiddleName)
                .HasMaxLength(20);

            ent.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(40);

            ent.Property(s => s.EnrollmentDate)
                .IsRequired();

            ent.Property(s => s.DateOfBirth)
                .IsRequired();
        });

        // Configuration for Course entity
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

        // Configuration for Enrollment entity
        modelBuilder.Entity<Enrollment>(ent =>
        {
            ent.HasKey(e => e.Id);

            ent.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            ent.Property(e => e.FinalGrade)
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

        modelBuilder.Entity<Instructor>(ent =>
        {
            ent.HasKey(i => i.Id);

            ent.Property(i => i.Id)
                .ValueGeneratedOnAdd();

            ent.Property(i => i.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            ent.Property(i => i.LastName)
                .IsRequired()
                .HasMaxLength(20);

            ent.Property(i => i.HireDate)
                .IsRequired();

            ent.HasMany<Course>()
                .WithOne()
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);

            ent.HasOne<Department>().
                WithOne(d => d.DepartmentHead);
        });

        modelBuilder.Entity<Department>(ent =>
        {
            ent.HasKey(d => d.Id);

            ent.Property(d => d.Id)
                .ValueGeneratedOnAdd();

            ent.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            ent.Property(d => d.Budget)
                .IsRequired();

            ent.Property(d => d.StartDate)
                .IsRequired();

            ent.HasOne(d => d.DepartmentHead)
                .WithOne()
                .HasForeignKey<Department>(d => d.DepartmentHeadId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}