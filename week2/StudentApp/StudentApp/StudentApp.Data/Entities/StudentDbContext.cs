using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentApp.Data.Entities
{
    public partial class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
        }

        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:training-tshjones.database.windows.net,1433;Initial Catalog=StudentDb;Persist Security Info=False;User ID=Gwyrddu;Password=Retsnif1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasIndex(e => e.CourseNumber)
                    .HasName("UQ__Class__A98290ED153ACBE3")
                    .IsUnique();

                entity.Property(e => e.CourseNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Class__4F7CD00D");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Enrollmen__Stude__4E88ABD4");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
