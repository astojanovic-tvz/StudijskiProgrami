namespace HKOWebMVC4.Migrations.HKO_WEB
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicijalnaMigracija : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KorisnikOdabranaZanimanjas",
                c => new
                    {
                        korisnikOdabranaZanimanjaId = c.Int(nullable: false, identity: true),
                        zanimanjeId = c.Int(nullable: false),
                        zanimanjeNaziv = c.String(),
                        userProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.korisnikOdabranaZanimanjaId)
                .ForeignKey("dbo.UserProfileInfoes", t => t.userProfile_Id, cascadeDelete: true)
                .Index(t => t.userProfile_Id);
            
            CreateTable(
                "dbo.UserProfileInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        JMBAG = c.String(),
                        Država = c.String(),
                        Grad = c.String(),
                        Adresa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KorisnikOdabranaZanimanjas", "userProfile_Id", "dbo.UserProfileInfoes");
            DropIndex("dbo.KorisnikOdabranaZanimanjas", new[] { "userProfile_Id" });
            DropTable("dbo.UserProfileInfoes");
            DropTable("dbo.KorisnikOdabranaZanimanjas");
        }
    }
}
