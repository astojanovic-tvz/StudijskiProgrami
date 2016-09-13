Ovdje ću upisivati korisne stvari, kao i napomene.

1) Prilikom proširivanja korisnika za dodatne atribute, mijenjao sam ApplicationUser klasu, kao po tutorialu sa linka: 
	http://www.asp.net/mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on
	Na tom linku također objašnjavaju kako dodati ulogiranje pomoću Googla ili Facebooka. 

2) Odradio sam i migracije nad bazom, kako sam mijenjao model. To sam odradio po tutorialu sa linka:
	http://stackoverflow.com/questions/21537558/multiple-db-contexts-in-the-same-db-and-application-in-ef-6-and-code-first-migra

3) Prebacivanje s ApplicationDbContext na HKO_WEB:
	Prvo je potrebno dohvatiti Connection od postojeće baze. 
	Spajanje na postojeću bazu:

	https://msdn.microsoft.com/en-us/library/jj200620.aspx
	https://msdn.microsoft.com/en-us/library/dn579398.aspx
	http://stackoverflow.com/questions/23662755/how-to-add-new-table-to-existing-database-code-first
	https://msdn.microsoft.com/en-gb/data/jj554735.aspx

	Nakon toga se dobije konekcija koja služi za spajanje na tu bazu.
	Nakon što imamo konekciju, potrebno je omogućiti Automatic-Migrations kako se ne bi dogodilo da Entity radi 
	Drop/Create.
	http://stackoverflow.com/questions/19902756/asp-net-identity-dbcontext-confusion
	http://stackoverflow.com/questions/19308959/set-asp-net-identity-connectionstring-property-in-net-4-5-1
	http://stackoverflow.com/questions/19474662/map-tables-using-fluent-api-in-asp-net-mvc5-ef6

	http://stackoverflow.com/questions/28531201/entitytype-identityuserlogin-has-no-key-defined-define-the-key-for-this-entit
	http://stackoverflow.com/questions/18297052/asp-net-identity-how-to-set-target-db
	http://stackoverflow.com/questions/13469881/how-do-i-enable-ef-migrations-for-multiple-contexts-to-separate-databases - Odgovor od bart s
	// Enable-Migrations -MigrationsDirectory "Migrations\HKO_WEB" -ContextTypeName HKOWebMVC4.HKO_WEB
	Nakon ove naredbe dobije se Configuration.cs klasa koja označava našu novu HKO_WEB konekciju i konfiguraciju za njezine migracije
	// Add-Migration -ConfigurationTypeName HKOWebMVC4.Migrations.HKO_WEB.Configuration "Inicijalna Migracija"
	Ova naredba stvara skriptu za diff baze i eventualne naredbe za kreiranje tablica i slično.
	// Update-Database -ConfigurationTypeName HKOWebMVC4.Migrations.HKO_WEB.Configuration
	Ova naredba odrađuje naredbe iz prijašnje skripte. Da bi se bilo što dogodilo, moramo dodati DbSet sa željenim tablicama.
	Pošto želimo da naš HKO_WEB sadrži i podatke za login, moramo naslijediti IdentityDbContext<ApplicationUser> koji u sebi sadrži
	tablice povezane sa Identityem. Samo ta promjena nad HKO_WEB nije dovoljna, već je potrebno dodati i 
	base.OnModelCreating(modelBuilder); naredbu da Identity modeli pokupe naredbe iz IdentityDbContext<ApplicationUser> klase. 
	Jednom kad setup-amo HKO_WEB.cs na ovaj način možemo ponoviti Add-Migration - Update-Database postupak i sada 
	naša baza sadrži sve tablice za Identity. 



Bower packages problem:

http://stackoverflow.com/questions/28725727/vs-2015-bower-does-not-work-behind-firewall/29605933#29605933