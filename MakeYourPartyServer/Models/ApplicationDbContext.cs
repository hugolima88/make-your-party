using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MakeYourPartyServer.Models.EntityConfiguration;

namespace MakeYourPartyServer.Models
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<InviteModel> Invites { get; set; }
        public DbSet<PartyModel> Parties { get; set; }
        public DbSet<MusicModel> Musics { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new PartyEntityConfiguration());
            modelBuilder.Configurations.Add(new InviteEntityConfiguration());
            modelBuilder.Configurations.Add(new MusicEntityConfiguration());

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}