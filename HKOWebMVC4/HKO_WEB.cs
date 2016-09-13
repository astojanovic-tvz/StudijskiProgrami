namespace HKOWebMVC4
{
    using System.Data.Entity;
    using Models;
    using Models.HKOWebModels.Korisnik;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration.Conventions;
    public partial class HKO_WEB : IdentityDbContext<ApplicationUser>
    {
        public HKO_WEB()
            : base("name=HKO_WEB", throwIfV1Schema: false)
        {
        }

        public static HKO_WEB Create()
        {
            return new HKO_WEB();
        }

        public DbSet<UserProfileInfo> UserProfileInfo { get; set; }
        public DbSet<KorisnikOdabranaZanimanja> KorisnikOdabranaZanimanja { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
