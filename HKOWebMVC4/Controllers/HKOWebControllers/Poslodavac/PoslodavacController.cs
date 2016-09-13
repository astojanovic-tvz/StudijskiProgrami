using HKOWebMVC4.DAL.HKOPodaciService;
using HKOWebMVC4.DAL.Repository.UserServices;
using HKOWebMVC4.DAL.Service.PoslodavacService;
using HKOWebMVC4.Models;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HKOWebMVC4.Controllers.HKOWebControllers.Poslodavac
{
    [Authorize]
    public class PoslodavacController : Controller
    {

        #region members
        private static HKOPodaci HKOData = new HKOPodaci();
        private static UserService userService = new UserService();
        private static HKOPodaciService HKODataService = new HKOPodaciService();
        #endregion

        // GET: Poslodavac
        [MvcSiteMapNodeAttribute(Title = "Poslodavac postavke", ParentKey = "Home", Key = "PoslodavacIndex")]
        public ActionResult Index()
        {
            KorisnikOdabirZanimanja odabirZanimanja = new KorisnikOdabirZanimanja();
            odabirZanimanja.svaZanimanja = HKODataService.fetchDistinctZanimanjaDictionary();
            odabirZanimanja.odabranaZanimanja = userService.getSelectedProffesionForCurrentUser();
            return View("~/Views/HKOWebViews/Poslodavac/Index.cshtml", odabirZanimanja);
        }

        [MvcSiteMapNodeAttribute(Title = "Pregled kandidata", ParentKey = "PoslodavacIndex", Key = "KandidatiPoslodavca")]
        public ActionResult Kandidati()
        {
            List<KorisnikOdabranaZanimanja> trazenaZanimanja = userService.getSelectedProffesionForCurrentUser();
            List<UserProfileInfo> kandidati = userService.fetchUsersByProffesionsList(trazenaZanimanja);
            return View("~/Views/HKOWebViews/Poslodavac/Kandidati.cshtml", kandidati);
        }
    }
}
