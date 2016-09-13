using ISVU_API.DetaljniUpisniList;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HKOWebMVC4.Controllers.HKOWebControllers.Studenti
{
    public class StudentiController : Controller
    {

        private static HKOPodaci hkoPodaci = new HKOPodaci();
        private static ISVU_API.Isvu ISVU = new ISVU_API.Isvu();

        // GET: Studenti
        public ActionResult Index()
        {
            return View();
        }

        [MvcSiteMapNodeAttribute(Title = "Kompetencije studenta", ParentKey = "PoslodavacIndex", Key = "StudentKompetencije",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.StudentiProviders.JMBAGDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kompetencije(string JMBAG)
        {

            List<ISVU_API.DetaljniUpisniList.upisaniPredmet> listaPredmeta = ISVU.UpisniListovi(JMBAG);
            HashSet<KolegijKompetencije_Result> setKompetencija = new HashSet<KolegijKompetencije_Result>();

            foreach(upisaniPredmet predmeti in listaPredmeta)
            {
                ObjectResult<KolegijKompetencije_Result> listaKompetencija = hkoPodaci.KolegijKompetencije("128193");
                
                foreach (KolegijKompetencije_Result kompetencija in listaKompetencija)
                {
                    bool postoji = false;
                    foreach(KolegijKompetencije_Result spremljeneKompetencije in setKompetencija.ToList())
                    {
                        if(spremljeneKompetencije.IDKompetencija == kompetencija.IDKompetencija)
                        {
                            postoji = true;
                            break;
                        }
                    }
                    if (!postoji)
                    {
                        setKompetencija.Add(kompetencija);
                    }                    
                }
            }
            ViewBag.back = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View("~/Views/HKOWebViews/Studenti/StudentiKompetencije.cshtml", setKompetencija);
        }
    }
}