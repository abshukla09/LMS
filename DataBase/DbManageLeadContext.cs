using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LMS.Models;

namespace LMS.DataBase;

public partial class DbManageLeadContext : DbContext
{
    public DbManageLeadContext()
    {
    }

    public DbManageLeadContext(DbContextOptions<DbManageLeadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEnquiry> TblEnquiries { get; set; }

    public virtual DbSet<TblEnquiryFollowup> TblEnquiryFollowups { get; set; }

    public virtual DbSet<TblEnquiryStatusMaster> TblEnquiryStatusMasters { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserEnquiry> TblUserEnquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEnquiry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Enqu__3214EC2736048D8A");

            entity.ToTable("tbl_Enquiry");

            entity.HasIndex(e => e.EmailId, "IX_tbl_Enquiry_EmailID");

            entity.HasIndex(e => e.MobileNo, "IX_tbl_Enquiry_MobileNo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.IsVerified).HasDefaultValue(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Purpose)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Status).WithMany(p => p.TblEnquiries)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enquiry_Status");
        });

        modelBuilder.Entity<TblEnquiryFollowup>(entity =>
        {
            entity.HasKey(e => e.FollowupId).HasName("PK__tbl_Enqu__C6356271E6F9BCF3");

            entity.ToTable("tbl_EnquiryFollowup");

            entity.Property(e => e.FollowupId).HasColumnName("FollowupID");
            entity.Property(e => e.EnquiryId).HasColumnName("EnquiryID");
            entity.Property(e => e.FollowupDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FollowupDetail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NextFollowUp).HasDefaultValue(false);
            entity.Property(e => e.NextFollowupDate).HasColumnType("datetime");

            entity.HasOne(d => d.Enquiry).WithMany(p => p.TblEnquiryFollowups)
                .HasForeignKey(d => d.EnquiryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Followup_Enquiry");
        });

        modelBuilder.Entity<TblEnquiryStatusMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_Enqu__3214EC2736C608A3");

            entity.ToTable("tbl_EnquiryStatusMaster");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__1788CCACA54366DF");

            entity.ToTable("tbl_User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FName");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LName");
            entity.Property(e => e.Mname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MName");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUserEnquiry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_User__3214EC27649E70C4");

            entity.ToTable("tbl_UserEnquiry");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EnquiryId).HasColumnName("EnquiryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Enquiry).WithMany(p => p.TblUserEnquiries)
                .HasForeignKey(d => d.EnquiryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEnquiry_Enquiry");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserEnquiries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserEnquiry_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
