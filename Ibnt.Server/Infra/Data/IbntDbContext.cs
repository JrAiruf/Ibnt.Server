
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

        //USERS
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<AuthCredentialEntity> Credentials { get; set; }
        public DbSet<RecoveryPasswordEntity> RecoveryPasswords { get; set; }

        //TIMELINE
        public DbSet<TimeLineEntity> TimeLine { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<BibleMessageEntity> BibleMessages { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

        //REACTIONS
        public DbSet<ReactionEventEntity> EventReactions { get; set; }
        public DbSet<ReactionBibleMessageEntity> BibleMessageReactions { get; set; }
        public DbSet<ReactionPostEntity> PostReactions { get; set; }

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

            //TIMELINE ENTITY
            modelBuilder.Entity<TimeLineEntity>(timeline =>
            {
                timeline.Property(e => e.PostDate).HasConversion(typeof(string));
                timeline.Property(e => e.CreationDate).HasConversion(typeof(string));
                timeline.Property(e => e.Date).HasConversion(typeof(string));
            });

            //EVENT ENTITY
            modelBuilder.Entity<EventEntity>(eventEntity =>
            {
                eventEntity.Property(e => e.Id).HasConversion(typeof(string));
                eventEntity.Property(e => e.PostDate).HasConversion(typeof(string));
                eventEntity.Property(e => e.CreationDate).HasConversion(typeof(string));
                eventEntity.Property(e => e.Date).HasConversion(typeof(string));
                eventEntity.HasOne(e => e.TimeLine).WithMany(t => t.Events);
            });

            //BIBLEMESSAGE ENTITY
            modelBuilder.Entity<BibleMessageEntity>(
                message =>
                {
                    message.Property(m => m.Id).HasConversion(typeof(string));
                    message.Property(m => m.PostDate).HasConversion(typeof(string));
                    message.Property(m => m.CreationDate).HasConversion(typeof(string));
                    message.Property(m => m.Date).HasConversion(typeof(string));
                    message.HasOne(m => m.TimeLine).WithMany(t => t.BibleMessages);
                });

            //POST ENTITY
            modelBuilder.Entity<PostEntity>(
                post =>
                {
                    post.Property(p => p.Id).HasConversion(typeof(string));
                    post.Property(p => p.PostDate).HasConversion(typeof(string));
                    post.Property(p => p.CreationDate).HasConversion(typeof(string));
                    post.Property(p => p.Date).HasConversion(typeof(string));
                });

            //REACTION
            modelBuilder.Entity<ReactionEventEntity>(
                         reaction =>
                         {
                             reaction.HasKey(r => new { r.MemberId, r.EventId });
                         });

            modelBuilder.Entity<ReactionEventEntity>(reaction =>
                        {
                            reaction.Property(r => r.MemberId).HasConversion(typeof(string));
                            reaction.Property(r => r.EventId).HasConversion(typeof(string));
                        });

            //REACTION
            modelBuilder.Entity<ReactionBibleMessageEntity>(
                         reaction =>
                         {
                             reaction.HasKey(r => new { r.MemberId, r.BibleMessageId });
                         });

            modelBuilder.Entity<ReactionBibleMessageEntity>(reaction =>
                        {
                            reaction.Property(r => r.MemberId).HasConversion(typeof(string));
                            reaction.Property(r => r.BibleMessageId).HasConversion(typeof(string));
                        });
            //REACTION
            modelBuilder.Entity<ReactionPostEntity>(
                         reaction =>
                         {
                             reaction.HasKey(r => new { r.MemberId, r.PostId });
                         });

            modelBuilder.Entity<ReactionPostEntity>(reaction =>
                        {
                            reaction.Property(r => r.MemberId).HasConversion(typeof(string));
                            reaction.Property(r => r.PostId).HasConversion(typeof(string));
                        });

        }
    }
}
