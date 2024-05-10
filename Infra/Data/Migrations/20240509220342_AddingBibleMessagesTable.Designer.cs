﻿// <auto-generated />
using System;
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    [DbContext(typeof(IbntDbContext))]
    [Migration("20240509220342_AddingBibleMessagesTable")]
    partial class AddingBibleMessagesTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EventEntityMemberEntity", b =>
                {
                    b.Property<string>("EventsId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("MembersId")
                        .HasColumnType("character varying(36)");

                    b.HasKey("EventsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("EventEntityMemberEntity");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessagesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BaseText")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("BibleMessages");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<Guid?>("BibleMessageId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<string>("EventId")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Toogled")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasAlternateKey("MemberId", "BibleMessageId");

                    b.HasAlternateKey("MemberId", "EventId");

                    b.HasIndex("BibleMessageId");

                    b.HasIndex("EventId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Date")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("PostDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.Auth.AuthCredentialEntity", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.Auth.RecoveryPasswordEntity", b =>
                {
                    b.Property<string>("VerificationCode")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("NewPassword")
                        .HasColumnType("text");

                    b.Property<string>("VerificationEmail")
                        .HasColumnType("text");

                    b.HasKey("VerificationCode");

                    b.ToTable("RecoveryPasswords");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.MemberEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("EventEntityMemberEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessagesEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithMany("BilbeMessages")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEntity", b =>
                {
                    b.HasOne("Ibnt.Domain.Entities.TimeLine.BibleMessagesEntity", "BibleMessage")
                        .WithMany("Reactions")
                        .HasForeignKey("BibleMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", "Event")
                        .WithMany("Reactions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithMany("Reactions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BibleMessage");

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.Auth.AuthCredentialEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithOne("Credential")
                        .HasForeignKey("Ibnt.Server.Domain.Entities.Users.Auth.AuthCredentialEntity", "MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessagesEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.MemberEntity", b =>
                {
                    b.Navigation("BilbeMessages");

                    b.Navigation("Credential");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
