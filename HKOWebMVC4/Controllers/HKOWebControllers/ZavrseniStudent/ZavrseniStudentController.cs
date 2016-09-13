using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HKOWebMVC4.Controllers.HKOWebControllers.ZavrseniStudent
{
    [Authorize]
    public class ZavrseniStudentController : Controller
    {
        #region member
        private static HKOPodaci HKOData = new HKOPodaci();
        #endregion

        [MvcSiteMapNode(Title = "Završeni student: Studijski programi", ParentKey = "Home", Key = "ZavrseniStudent")]
        public ActionResult Index()
        {
            ObjectResult<StudijskiProgrami_Result> zanimanjeStudijResult = HKOData.StudijskiProgrami();
            return View("~/Views/HKOWebViews/ZavrseniStudent/Index.cshtml", zanimanjeStudijResult);
        }

        [MvcSiteMapNodeAttribute(Title = "Radna mjesta", ParentKey = "ZavrseniStudent", Key = "ZSRadnaMjesta",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.ZavrseniStudentProviders.StudijskiProgramIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult RadnaMjesta(int? studijskiProgramId)
        {
            ObjectResult<StudijskiProgramRadnaMjesta_Result> radnaMjestaResult = HKOData.StudijskiProgramRadnaMjesta(studijskiProgramId);
            return View("~/Views/HKOWebViews/ZavrseniStudent/RadnaMjesta.cshtml", radnaMjestaResult);
        }

        [MvcSiteMapNodeAttribute(Title = "Ključni poslovi", ParentKey = "ZavrseniStudent", Key = "ZSKljucniPoslovi",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.ZavrseniStudentProviders.StudijskiProgramIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult KljucniPoslovi(int? studijskiProgramId)
        {
            ObjectResult<StudijskiProgramKljucniPoslovi_Result> kljucniPosloviResult = HKOData.StudijskiProgramKljucniPoslovi(studijskiProgramId);
            return View("~/Views/HKOWebViews/ZavrseniStudent/KljucniPoslovi.cshtml", kljucniPosloviResult);
        }

        [MvcSiteMapNodeAttribute(Title = "Kompetencije", ParentKey = "ZavrseniStudent", Key = "ZSKompetencije",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.ZavrseniStudentProviders.StudijskiProgramIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kompetencije(int? studijskiProgramId)
        {
            ObjectResult<StudijskiProgramKompetencije_Result> kompetencijeResult = HKOData.StudijskiProgramKompetencije(studijskiProgramId);
            return View("~/Views/HKOWebViews/ZavrseniStudent/Kompetencije.cshtml", kompetencijeResult);
        }
    }
}