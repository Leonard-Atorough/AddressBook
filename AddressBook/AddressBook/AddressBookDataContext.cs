using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace AddressBookModel
{
    public partial class AddressBookDataContext : DbContext
    {
        public AddressBookDataContext()
        {
        }

        public AddressBookDataContext(DbContextOptions<AddressBookDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserContact> UserContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                

                optionsBuilder.UseSqlServer("Data Source=(localdb)\ProjectsV13;Initial Catalog=AddressBookData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HomeNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.WorkNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Contacts__Addres__25869641");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserPassword, "UQ__Users__5DF58B81625E52BD")
                    .IsUnique();

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserContact>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ContactId });

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserConta__Conta__2C3393D0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserContacts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserConta__UserI__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
