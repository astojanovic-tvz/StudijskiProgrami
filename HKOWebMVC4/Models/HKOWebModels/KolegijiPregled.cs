using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HKOWebMVC4.Models.HKOWebModels {
    public class KolegijiPregled {
        public ObjectResult<StudijskiProgramObavezniKolegiji_Result> obavezniKolegijiResult { get; set; }
        public ObjectResult<StudijskiProgramIzborniKolegiji_Result> izborniKolegijiResult { get; set; }
        public ObjectResult<ZanimanjePreporuceniIzborniKolegiji_Result> preporuceniKolegijiResult { get; set; }
    }

    public class Kolegij {
        public int KolegijID { get; set; }
        public string Naziv { get; set; }
        public int Semestar { get; set; }
    }

    public class PopisKolegija {
        public List<Kolegij> ObavezniKolegiji { get; set; }
        public List<Kolegij> IzborniKolegiji { get; set; }
    }
}