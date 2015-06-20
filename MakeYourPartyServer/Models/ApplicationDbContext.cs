using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MakeYourPartyServer.Models
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<InviteModel> Invites { get; set; }
        public DbSet<PartyModel> Parties { get; set; }
        public DbSet<PartyMusicModel> Musics { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<UserModel>().ToTable("Users");
                //.HasRequired(c => c.Parties)
                //.WithMany()
                //.WillCascadeOnDelete(false);
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            //modelBuilder.Entity<PartyModel>()
            //    .HasRequired(c => c.User)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartyModel>()
                .HasRequired(c => c.User)
                .WithMany(c => c.Parties)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}