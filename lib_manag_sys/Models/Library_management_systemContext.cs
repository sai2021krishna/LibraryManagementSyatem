using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lib_manag_sys
{
    public partial class Library_management_systemContext : DbContext
    {
        public Library_management_systemContext()
        {
        }

        public Library_management_systemContext(DbContextOptions<Library_management_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Library_management_system;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__books__490D1AE19D9B5A59");

                entity.ToTable("books");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.BookAuthor)
                    .IsRequired()
                    .HasColumnName("book_author")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookEdition).HasColumnName("book_edition");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasColumnName("book_name")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("staff");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.StaffPasscode)
                    .IsRequired()
                    .HasColumnName("staff_passcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffUsername)
                    .IsRequired()
                    .HasColumnName("staff_username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
