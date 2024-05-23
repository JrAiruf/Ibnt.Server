﻿// <auto-generated />
using Ibnt.Server.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ibnt.Server.Infra.Data.Migrations
{
    [DbContext(typeof(IbntDbContext))]
    partial class IbntDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessageEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("BaseText")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("CreationDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Date")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("PostDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("BibleMessages");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.PostEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("CreationDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Date")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("PostDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionBibleMessageEntity", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("BibleMessageId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Toogled")
                        .HasColumnType("boolean");

                    b.HasKey("MemberId", "BibleMessageId");

                    b.HasIndex("BibleMessageId");

                    b.ToTable("BibleMessageReactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEventEntity", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("EventId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("MemberEntityId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Toogled")
                        .HasColumnType("boolean");

                    b.HasKey("MemberId", "EventId");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberEntityId");

                    b.ToTable("EventReactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionPostEntity", b =>
                {
                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("PostId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Toogled")
                        .HasColumnType("boolean");

                    b.HasKey("MemberId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("PostReactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("CreationDate")
                        .HasColumnType("character varying(48)");

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

                    b.Property<string>("MemberId")
                        .HasColumnType("character varying(36)");

                    b.Property<string>("PostDate")
                        .HasColumnType("character varying(48)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

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

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessageEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithMany("BibleMessages")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.PostEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionBibleMessageEntity", b =>
                {
                    b.HasOne("Ibnt.Domain.Entities.TimeLine.BibleMessageEntity", "BibleMessage")
                        .WithMany("Reactions")
                        .HasForeignKey("BibleMessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BibleMessage");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionEventEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", "Event")
                        .WithMany("Reactions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", null)
                        .WithMany("Reactions")
                        .HasForeignKey("MemberEntityId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Reactions.ReactionPostEntity", b =>
                {
                    b.HasOne("Ibnt.Domain.Entities.TimeLine.PostEntity", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithMany("Events")
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.Auth.AuthCredentialEntity", b =>
                {
                    b.HasOne("Ibnt.Server.Domain.Entities.Users.MemberEntity", "Member")
                        .WithOne("Credential")
                        .HasForeignKey("Ibnt.Server.Domain.Entities.Users.Auth.AuthCredentialEntity", "MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.BibleMessageEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Domain.Entities.TimeLine.PostEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.TimeLine.EventEntity", b =>
                {
                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Ibnt.Server.Domain.Entities.Users.MemberEntity", b =>
                {
                    b.Navigation("BibleMessages");

                    b.Navigation("Credential");

                    b.Navigation("Events");

                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
