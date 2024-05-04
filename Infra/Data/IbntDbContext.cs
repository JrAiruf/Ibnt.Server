﻿
using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Ibnt.Server.Infra.Data
{
    public class IbntDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                //options.UseSqlite(ApiConfiguration.ConnectionStringValue());
                options.UseNpgsql(ApiConfiguration.ConnectionStringValue());
            }
        }

        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<AuthCredentialEntity> Credentials { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<ReactionEntity> Reactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //USERS
            modelBuilder.Entity<MemberEntity>(member =>
            {
                member.HasOne(m => m.Credential)
                      .WithOne(auth => auth.Member);
                member.Property(m => m.Id).HasConversion(typeof(string), typeof(Guid));

            });

            modelBuilder.Entity<AuthCredentialEntity>(auth =>
            {
                auth.HasKey(a => a.Email);
                auth.Property(c => c.MemberId).HasConversion(typeof(string), typeof(Guid));
            });

            //TIMELINE
            modelBuilder.Entity<ReactionEntity>(
                         reaction => reaction
                        .HasKey(r => new { r.MemberId, r.EventId }
                        ));
        }
    }
}
