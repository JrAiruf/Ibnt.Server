
using Ibnt.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Reactions;
using Ibnt.Server.Domain.Entities.TimeLine;
using Ibnt.Server.Domain.Entities.Users;
using Ibnt.Server.Domain.Entities.Users.Auth;
using Ibnt.Server.Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace Ibnt.Server.Infra.Data
{
    public class IbntDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseNpgsql(ApiConfiguration.ConnectionStringValue());
            }
        }

        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<AuthCredentialEntity> Credentials { get; set; }
        public DbSet<RecoveryPasswordEntity> RecoveryPasswords { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<BibleMessageEntity> BibleMessages { get; set; }
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

            modelBuilder.Entity<RecoveryPasswordEntity>(rP =>
            {
                rP.HasKey(r => r.VerificationCode);
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
                         reaction =>
                         {
                             reaction.HasKey(r => r.Id);
                             reaction.HasAlternateKey(r => new { r.MemberId, r.EventId });
                             reaction.HasAlternateKey(r => new { r.MemberId, r.BibleMessageId });
                         });

            modelBuilder.Entity<ReactionEntity>(reaction =>
                        {
                            reaction.Property(r => r.Id).HasConversion(typeof(string));
                            reaction.Property(r => r.MemberId).HasConversion(typeof(string));
                            reaction.Property(r => r.EventId).HasConversion(typeof(string));
                        });

            modelBuilder.Entity<BibleMessageEntity>(
                message =>
                {
                    message.Property(m => m.Id).HasConversion(typeof(string));
                    message.Property(m => m.CreationDate).HasConversion(typeof(string));
                    message.Property(m => m.PostDate).HasConversion(typeof(string));
                    message.Property(m => m.Date).HasConversion(typeof(string));
                });
        }
    }
}
