﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VotingWorkshopBackend.Model;

namespace VotingWorkshopBackend.Model;

public partial class WssVotingWorkshopSystemContext : DbContext
{
    public WssVotingWorkshopSystemContext()
    {
    }

    public WssVotingWorkshopSystemContext(DbContextOptions<WssVotingWorkshopSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Saloon> Saloons { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }

    public virtual DbSet<SurveyOption> SurveyOptions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<WorkshopRequest> WorkshopRequests { get; set; }

    public virtual DbSet<WorkshopTimeslot> WorkshopTimeslots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JACKIE-MSI\\SQLEXPRESS;Database=WSS_VotingWorkshopSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Saloon>(entity =>
        {
            entity.ToTable("Saloon");

            entity.Property(e => e.SaloonName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.ToTable("Survey");

            entity.Property(e => e.Question)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.SurveyName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<SurveyAnswer>(entity =>
        {
            entity.HasKey(e => new { e.SurveyId, e.UserId });

            entity.ToTable("SurveyAnswer");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyAnswer_Survey");

            entity.HasOne(d => d.SurveyOption).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.SurveyOptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyAnswer_SurveyOption");

            entity.HasOne(d => d.User).WithMany(p => p.SurveyAnswers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyAnswer_User");
        });

        modelBuilder.Entity<SurveyOption>(entity =>
        {
            entity.ToTable("SurveyOption");

            entity.Property(e => e.SurveyOptionName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyOptions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SurveyOption_Survey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Tel)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.UserTypeName)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<WorkshopRequest>(entity =>
        {
            entity.ToTable("WorkshopRequest");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.LastUpdated).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopRequest_Category");

            entity.HasOne(d => d.Saloon).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.SaloonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopRequest_WorkshopRequest");

            entity.HasOne(d => d.Status).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopRequest_Status");

            entity.HasOne(d => d.User).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopRequest_User");

            entity.HasOne(d => d.WorkshopTimeslot).WithMany(p => p.WorkshopRequests)
                .HasForeignKey(d => d.WorkshopTimeslotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopRequest_WorkshopTimeslot");
        });

        modelBuilder.Entity<WorkshopTimeslot>(entity =>
        {
            entity.ToTable("WorkshopTimeslot");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
