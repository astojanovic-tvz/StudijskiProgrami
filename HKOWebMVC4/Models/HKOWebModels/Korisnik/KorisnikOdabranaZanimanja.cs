using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.Models.HKOWebModels.Korisnik
{
    public class KorisnikOdabranaZanimanja
    {
        public int korisnikOdabranaZanimanjaId { get; set; }
        public int zanimanjeId { get; set; }
        public string zanimanjeNaziv { get; set; }
        [Required]
        public virtual UserProfileInfo userProfile { get; set; }
    }
}