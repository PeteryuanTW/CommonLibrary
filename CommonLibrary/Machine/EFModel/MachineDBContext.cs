﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Machine
{
    public class MachineDBContext : DbContext
    {
        public MachineDBContext(DbContextOptions<MachineDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MachineStatusLog> MachineStatusLogs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<TagCategory> TagCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.UseTpcMappingStrategy();
                entity.ToTable("Machine");

                entity.HasIndex(e => e.Name).IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasColumnName("IP");

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.TagCategoryId).HasColumnName("TagCategoryID");
                entity.Property(e => e.LogicStatusCategoryId).HasColumnName("LogicStatusCategoryID");


                entity.HasOne(d => d.TagCategory).WithMany(p => p.Machines)
                    .HasForeignKey(d => d.TagCategoryId);

                entity.Property(e => e.Enabled).HasColumnName("Enabled");
                entity.Property(e => e.UpdateDelay).HasColumnName("UpdateDelay");
                entity.Property(e => e.MaxRetryCount).HasColumnName("MaxRetryCount");
                entity.Property(e => e.RecordStatusChanged).HasColumnName("RecordStatusChanged");

            });

            modelBuilder.Entity<MachineStatusLog>(entity =>
            {

                entity.ToTable("MachineStatusLogs");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.MachineID).HasColumnName("MachineID");
                entity.Property(e => e.Status).HasColumnName("Status");
                entity.Property(e => e.LogTime).HasColumnName("LogTime");
            });

            modelBuilder.Entity<TagCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TagCategory");

                entity.HasIndex(e => e.Name).IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Tag");

                entity.HasIndex(e => e.Name).IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.Bool1).HasColumnName("Bool_1");
                entity.Property(e => e.Bool2).HasColumnName("Bool_2");
                entity.Property(e => e.Bool3).HasColumnName("Bool_3");
                entity.Property(e => e.Bool4).HasColumnName("Bool_4");
                entity.Property(e => e.Bool5).HasColumnName("Bool_5");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.Int1).HasColumnName("Int_1");
                entity.Property(e => e.Int2).HasColumnName("Int_2");
                entity.Property(e => e.Int3).HasColumnName("Int_3");
                entity.Property(e => e.Int4).HasColumnName("Int_4");
                entity.Property(e => e.Int5).HasColumnName("Int_5");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.String1)
                    .HasMaxLength(50)
                    .HasColumnName("String_1");
                entity.Property(e => e.String2)
                    .HasMaxLength(50)
                    .HasColumnName("String_2");
                entity.Property(e => e.String3)
                    .HasMaxLength(50)
                    .HasColumnName("String_3");
                entity.Property(e => e.String4)
                    .HasMaxLength(50)
                    .HasColumnName("String_4");
                entity.Property(e => e.String5)
                    .HasMaxLength(50)
                    .HasColumnName("String_5");

                entity.HasOne(d => d.Category).WithMany(p => p.Tags)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientCascade);
                //.HasConstraintName("FK__Tag__CategoryID__68487DD7");
            });
        }
    }
}
