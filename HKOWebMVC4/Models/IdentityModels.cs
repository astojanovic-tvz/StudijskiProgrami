using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using System.Collections.Generic;
using System;

namespace HKOWebMVC4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual UserProfileInfo UserProfileInfo { get; set; }
    }

    public class UserProfileInfo
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBAG { get; set; }
        public string Država { get; set; }
        public string Grad { get; set; }
        public string Adresa { get; set; }
        public ICollection<KorisnikOdabranaZanimanja> odabranaZanimanja { get; set; }

    }
    //ime, prezime, JMBAG, email, korisničko ime i lozinka.
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    [Obsolete("ApplicationDbContext je defaultni Context iz MVC-a. Sve vezano uz bazu treba biti prebačeno na HKO_WEB.")]
    /// <see cref="HKO_WEB"/>
    public class ApplicationDbContext : DbContext //IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            //koga briga za migracije
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<UserProfileInfo> UserProfileInfo { get; set; }
        public DbSet<KorisnikOdabranaZanimanja> KorisnikOdabranaZanimanja { get; set; }

    }
}