using HKOWebMVC4.Models.HKOWebModels;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HKOWebMVC4.Controllers.HKOWebControllers.BuduciStudent
{
    [Authorize]
    public class BuduciStudentController : Controller
    {
        #region member
        private static HKOPodaci HKOData = new HKOPodaci();
        #endregion

        // GET: BuduciStudent
        [MvcSiteMapNode(Title = "Budući student: Zanimanja i studiji", ParentKey = "Home", Key = "BuduciStudent")]
        public ActionResult Index()
        {
            ObjectResult<ZanimanjeStudiji_Result> zanimanjeStudijResult = HKOData.ZanimanjeStudiji();
            return View("~/Views/HKOWebViews/BuduciStudent/Index.cshtml", zanimanjeStudijResult);
        }

        // GET: BuduciStudent/Details/5
        [MvcSiteMapNodeAttribute(Title = "Radna mjesta", ParentKey = "BuduciStudent", Key = "BSRadnaMjesta", 
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult RadnaMjesta(int? zanimanjeId)
        {
            ObjectResult<ZanimanjeRadnaMjesta_Result> radnaMjestaResult = HKOData.ZanimanjeRadnaMjesta(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/RadnaMjesta.cshtml", radnaMjestaResult);
        }

        // GET: BuduciStudent/Create
        [MvcSiteMapNodeAttribute(Title = "Ključni Poslovi", ParentKey = "BuduciStudent", Key = "BSKljucniPoslovi",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult KljucniPoslovi(int zanimanjeId)
        {
            ObjectResult<ZanimanjeKljucniPoslovi_Result> kljucniPosloviResult = HKOData.ZanimanjeKljucniPoslovi(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/KljucniPoslovi.cshtml", kljucniPosloviResult);
        }

        // GET: BuduciStudent/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Kompetencije", ParentKey = "BuduciStudent", Key = "BSKompetencije",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kompetencije(int zanimanjeId)
        {
            ObjectResult<ZanimanjeKompetencije_Result> zanimanjeKompetencijeResult = HKOData.ZanimanjeKompetencije(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/Kompetencije.cshtml", zanimanjeKompetencijeResult);
        }

        [MvcSiteMapNodeAttribute(Title = "Kolegiji", ParentKey = "BuduciStudent",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.StudijskiProgramIDZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kolegiji(int studijskiProgramId, int zanimanjeId)
        {
            KolegijiPregled kolegijiPregled = new KolegijiPregled();
            kolegijiPregled.obavezniKolegijiResult = HKOData.StudijskiProgramObavezniKolegiji(studijskiProgramId);
            kolegijiPregled.izborniKolegijiResult = HKOData.StudijskiProgramIzborniKolegiji(studijskiProgramId);
            kolegijiPregled.preporuceniKolegijiResult = HKOData.ZanimanjePreporuceniIzborniKolegiji(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/Kolegiji.cshtml", kolegijiPregled);
        }

        [MvcSiteMapNodeAttribute(Title = "Kompetencije", Key = "BSIshodiUcenja",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.KolegijIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        // GET: BuduciStudent/Delete/5
        public ActionResult IshodiUcenja(int kolegijId)
        {
            ViewBag.back = System.Web.HttpContext.Current.Request.UrlReferrer;
            ObjectResult<KolegijSkupIshodaUcenja_Result> ishodiUcenjaResult = HKOData.KolegijSkupIshodaUcenja(kolegijId);
            return View("~/Views/HKOWebViews/BuduciStudent/IshodiUcenja.cshtml", ishodiUcenjaResult);
        }
    }
}
