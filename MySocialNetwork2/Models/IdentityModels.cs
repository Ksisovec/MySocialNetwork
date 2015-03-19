using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MySocialNetwork2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Task> Task { get; set; }
        public virtual ICollection<Comment> Commet { get; set; }
        public virtual ICollection<ReferenceToTask> Reference { set; get; }
        public virtual ICollection<SolvedTask> SolvedTask { get; set; }

        public int RatingUser { get; set; }


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
        public DbSet<Task> Task { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Commentses { get; set; }
        public DbSet<ReferenceToTask> ReferenceToTasks { get; set; }
        public DbSet<SolvedTask> SolvedTasks { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}