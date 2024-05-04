
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
                IApiConfiguration apiConfig = new ApiConfiguration(this);
                //options.UseSqlite(apiConfig.ConnectionStringValue());
                options.UseNpgsql(apiConfig.ConnectionStringValue());
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
                member.Property(m => m.Id).HasConversion(typeof(string));

            });

            modelBuilder.Entity<AuthCredentialEntity>(auth =>
            {
                auth.HasKey(a => a.Email);
                auth.Property(c => c.MemberId).HasConversion(typeof(string));
            });

            //TIMELINE
            modelBuilder.Entity<EventEntity>(eventEntity =>
            {
                eventEntity.Property(e => e.Id).HasConversion(typeof(string));
                eventEntity.Property(e => e.PostDate).HasConversion(typeof(string));
                eventEntity.Property(e => e.Date).HasConversion(typeof(string));
            });
            modelBuilder.Entity<ReactionEntity>(
                         reaction => reaction
                        .HasKey(r => new { r.MemberId, r.EventId }
                        ));
            modelBuilder.Entity<ReactionEntity>(reaction =>
            {
                reaction.Property(r => r.MemberId).HasConversion(typeof(string));
                reaction.Property(r => r.EventId).HasConversion(typeof(string));
            }
            );

        }
    }
}
