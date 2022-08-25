﻿// <auto-generated />
using System;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    [Migration("20220825093307_TgIdAddedTwo")]
    partial class TgIdAddedTwo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("DAL.Entities.Couple", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Couples");
                });

            modelBuilder.Entity("DAL.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("PrivateType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DAL.Entities.HomeworkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<byte>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Homework");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPractice")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Teacher")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageLocation")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("TelegramToken")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DAL.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsModerator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("DAL.Entities.Couple", b =>
                {
                    b.HasOne("DAL.Entities.Group", "Group")
                        .WithMany("Couples")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Subject", "Subject")
                        .WithMany("Couples")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DAL.Entities.HomeworkTask", b =>
                {
                    b.HasOne("DAL.Entities.Subject", "Subject")
                        .WithMany("Homework")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("Homework")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.HasOne("DAL.Entities.Group", "OwnerGroup")
                        .WithMany("Subjects")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerGroup");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.OwnsOne("DAL.Entities.Settings", "Settings", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("NotifyAboutCouple")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("NotifyAboutDeadlineHomework")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("NotifyAboutHomework")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("NotifyAboutLoseDeadlineHomework")
                                .HasColumnType("INTEGER");

                            b1.Property<bool>("NotifyBeforeCouple")
                                .HasColumnType("INTEGER");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("DAL.Entities.Tokens", "Token", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("RefreshToken")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Token")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("TokenCreated")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("TokenExpires")
                                .HasColumnType("TEXT");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Settings")
                        .IsRequired();

                    b.Navigation("Token")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.UserRole", b =>
                {
                    b.HasOne("DAL.Entities.Group", "Group")
                        .WithMany("UsersRoles")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UsersRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Group", b =>
                {
                    b.Navigation("Couples");

                    b.Navigation("Subjects");

                    b.Navigation("UsersRoles");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.Navigation("Couples");

                    b.Navigation("Homework");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Homework");

                    b.Navigation("UsersRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
