using HKOWebMVC4.Models.HKOWebModels;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace HKOWebMVC4.Controllers.HKOWebControllers.StudijskiProgrami {
    [Authorize]
    public class StudijskiProgramiController : Controller {
        #region member
        private static HKOPodaci HKOData = new HKOPodaci();
        #endregion

        // GET: BuduciStudent
        [MvcSiteMapNode(Title = "Studijski programi i silabus", ParentKey = "Home", Key = "StudijskiProgrami")]
        public ActionResult Index() {
            ObjectResult<StudijskiProgrami_Result> studijskiProgramiResult = HKOData.StudijskiProgrami();
            return View("~/Views/HKOWebViews/StudijskiProgrami/Index.cshtml", studijskiProgramiResult);
        }

        // GET: BuduciStudent/Details/5
        //[MvcSiteMapNodeAttribute(Title = "Obavezni kolegiji", ParentKey = "StudijskiProgrami", Key = "SPObavezniKolegiji",
        //    DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kolegiji(int? studijskiProgramId) {
            //KolegijiPregled kolegijiPregled = new KolegijiPregled();
            //kolegijiPregled.obavezniKolegijiResult = HKOData.StudijskiProgramObavezniKolegiji(studijskiProgramId);
            //kolegijiPregled.izborniKolegijiResult = HKOData.StudijskiProgramIzborniKolegiji(studijskiProgramId);
            //return View("~/Views/HKOWebViews/StudijskiProgrami/StudijskiProgramiObavezniKolegiji.cshtml", kolegijiPregled);

            DataSet ds = Util.DB.PozoviSP("web.StudijskiProgramIzborniKolegiji", new List<SqlParameter> { new SqlParameter("StudijskiProgramID", studijskiProgramId) });
            List<Kolegij> izborni = new List<Kolegij>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                int idKolegija = (int)ds.Tables[0].Rows[i]["KolegijID"];
                string nazivKolegija = (string)ds.Tables[0].Rows[i]["Kolegij"];
                int semestarKolegija = (int)ds.Tables[0].Rows[i]["Semestar"];

                izborni.Add(new Kolegij { KolegijID = idKolegija, Naziv = nazivKolegija, Semestar = semestarKolegija });
            }

            ds = Util.DB.PozoviSP("web.StudijskiProgramObavezniKolegiji", new List<SqlParameter> { new SqlParameter("StudijskiProgramID", studijskiProgramId) });
            List<Kolegij> obavezni = new List<Kolegij>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                int idKolegija = (int)ds.Tables[0].Rows[i]["KolegijID"];
                string nazivKolegija = (string)ds.Tables[0].Rows[i]["Kolegij"];
                int semestarKolegija = (int)ds.Tables[0].Rows[i]["Semestar"];

                obavezni.Add(new Kolegij { KolegijID = idKolegija, Naziv = nazivKolegija, Semestar = semestarKolegija });
            }

            PopisKolegija kolegiji = new PopisKolegija { ObavezniKolegiji = obavezni, IzborniKolegiji = izborni };

            return View("~/Views/HKOWebViews/StudijskiProgrami/StudijskiProgramiObavezniKolegiji.cshtml", kolegiji);
        }

        // GET: BuduciStudent/Create
        //[MvcSiteMapNodeAttribute(Title = "Ključni Poslovi", ParentKey = "StudijskiProgrami", Key = "SPKljucniPoslovi",
        //    DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Silabus(int kolegijId) {
            try {
                DataSet ds = Util.DB.PozoviSP("web.KolegijSilabus", new List<SqlParameter> { new SqlParameter("KolegijID", kolegijId) });

                string ime = (string)ds.Tables[0].Rows[0]["DokumentNaziv"];
                byte[] sadrzaj = (byte[])ds.Tables[0].Rows[0]["DokumentBlob"];

                FileStream fs = new FileStream("C:\\Users\\Public\\" + ime, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(sadrzaj);
                bw.Close();

                return File("C:\\Users\\Public\\" + ime, "application/rtf");
            } catch (Exception) {
                return null;
            }
        }
/*
        // GET: BuduciStudent/Edit/5
        [MvcSiteMapNodeAttribute(Title = "Kompetencije", ParentKey = "StudijskiProgrami", Key = "SPKompetencije",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.ZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kompetencije(int zanimanjeId) {
            ObjectResult<ZanimanjeKompetencije_Result> zanimanjeKompetencijeResult = HKOData.ZanimanjeKompetencije(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/Kompetencije.cshtml", zanimanjeKompetencijeResult);
        }

        [MvcSiteMapNodeAttribute(Title = "Kolegiji", ParentKey = "StudijskiProgrami",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.StudijskiProgramIDZanimanjeIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        public ActionResult Kolegiji(int studijskiProgramId, int zanimanjeId) {
            KolegijiPregled kolegijiPregled = new KolegijiPregled();
            kolegijiPregled.obavezniKolegijiResult = HKOData.StudijskiProgramObavezniKolegiji(studijskiProgramId);
            kolegijiPregled.izborniKolegijiResult = HKOData.StudijskiProgramIzborniKolegiji(studijskiProgramId);
            kolegijiPregled.preporuceniKolegijiResult = HKOData.ZanimanjePreporuceniIzborniKolegiji(zanimanjeId);
            return View("~/Views/HKOWebViews/BuduciStudent/Kolegiji.cshtml", kolegijiPregled);
        }

        [MvcSiteMapNodeAttribute(Title = "Kompetencije", Key = "SPIshodiUcenja",
            DynamicNodeProvider = "HKOWebMVC4.SiteMapNodeProviders.BuduciStudentProviders.KolegijIDDeterminedDynamicNodeProvider, HKOWebMVC4")]
        // GET: BuduciStudent/Delete/5
        public ActionResult IshodiUcenja(int kolegijId) {
            ViewBag.back = System.Web.HttpContext.Current.Request.UrlReferrer;
            ObjectResult<KolegijSkupIshodaUcenja_Result> ishodiUcenjaResult = HKOData.KolegijSkupIshodaUcenja(kolegijId);
            return View("~/Views/HKOWebViews/BuduciStudent/IshodiUcenja.cshtml", ishodiUcenjaResult);
        }
        */
    }
}
