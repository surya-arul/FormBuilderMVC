﻿using System;
using System.Collections.Generic;
using FormBuilderMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FormBuilderMVC.DbContexts;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblInput> TblInputs { get; set; }

    public virtual DbSet<TblSurvey> TblSurveys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblInput__3214EC07465A90AC");

            entity.ToTable("tblInputs");

            entity.Property(e => e.DivClassName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InputClassName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InputType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InternalName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Label)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LabelClassName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OptionData).IsUnicode(false);
            entity.Property(e => e.Placeholder)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Survey).WithMany(p => p.TblInputs)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tblInputs__Surve__4222D4EF");
        });

        modelBuilder.Entity<TblSurvey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblSurve__3214EC0706CEA9CA");

            entity.ToTable("tblSurveys");

            entity.Property(e => e.FormAction)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FormMethod)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
