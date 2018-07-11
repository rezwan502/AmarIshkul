using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AmarIshkul.Entity;

namespace AmarIshkul.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class AmarIshkulDBContext : IdentityDbContext<ApplicationUser>
    {
        public AmarIshkulDBContext()
            : base("AmarIshkulDb", throwIfV1Schema: false)
        {
        }

        public static AmarIshkulDBContext Create()
        {
            return new AmarIshkulDBContext();
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectChapterSetup> SubjectChapterSetups { get; set; }
        public DbSet<SubjectChapterWiseDetails> SubjectChapterWiseDetails { get; set; }

        public DbSet<SubjectChapterQuestionSetup> SubjectChapterQuestionSetups { get; set; }
        public DbSet<SubjectChapterQuestionDetails> SubjectChapterQuestionDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ForeignKeyIndexConvention>();
        }
    }
}