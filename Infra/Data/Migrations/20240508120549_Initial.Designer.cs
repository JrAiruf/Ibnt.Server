﻿// <auto-generated />
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
    [Migration("20240508120549_Initial")]
    partial class Initial
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

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEntity", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("EventId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Toogled")
                        .HasColumnType("boolean");

                    b.HasKey("MemberId", "EventId");

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

                    b.Property<string>("Date")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Description")
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

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEntity", b =>
                {
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

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.MemberEntity", b =>
                {
                    b.Navigation("Credential");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}