using HKOWebMVC4.DAL.HKOPodaciService;
using HKOWebMVC4.DAL.Repository.UserServices;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.Models.HKOWebModels.Korisnik
{
    public class KorisnikOdabirZanimanja
    {
        public KorisnikOdabirZanimanja() { }
        public KorisnikOdabirZanimanja(UserProfileInfo user)
        {
            HKOPodaciService podaciService = new HKOPodaciService();
            UserService userService = new UserService();
            this.svaZanimanja = podaciService.fetchDistinctZanimanjaDictionary();
            this.odabranaZanimanja = userService.getSelectedProffesionsForUser(user);
        }

        public Dictionary<int, string> svaZanimanja { get; set; }
        public List<KorisnikOdabranaZanimanja> odabranaZanimanja { get; set; }

    }
}