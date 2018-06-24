using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mnk.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }
        public string MobileNo { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string User_Adress { get; set; }
        public bool Status { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
        public DbSet<Services> Servicess { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Board_Location> Boards_Locations { get; set; }
        public DbSet<Board_Availbality> Boards_Availability { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.slider> sliders { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Gallery> Galleries { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.testo_nomia> testo_nomia { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Board_city> Board_city { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Board_medium> Board_medium { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.client> clients { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Services_details> Services_details { get; set; }

        public System.Data.Entity.DbSet<Mnk.Models.Board_image> Board_image { get; set; }
    }
}