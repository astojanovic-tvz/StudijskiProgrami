using HKOWebMVC4.DAL.Repository.UserServices;
using HKOWebMVC4.Models.HKOWebModels.AjaxModels;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HKOWebMVC4.Controllers.HKOWebControllers.User
{
    public class UserController : Controller
    {
        private static UserService userService = new UserService();
        private _AjaxResponseModel ajaxResponse = new _AjaxResponseModel();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveChosenProffesion(List<KorisnikOdabranaZanimanja> odabranaZanimanja)
        {
            var currentUser = userService.fetchCurrentUser().UserProfileInfo;
            try
            {
                ajaxResponse = userService.removeSelectedProffesionsForUser(currentUser);
                if (odabranaZanimanja != null && odabranaZanimanja.Count > 0)
                {
                    ajaxResponse = userService.setSelectedProffesionsForUser(odabranaZanimanja, userService.fetchCurrentUser().UserProfileInfo);
                }
            }
            catch (Exception e)
            {
                ajaxResponse.message = "Akcija neuspjela!\n" + e.StackTrace;
                ajaxResponse.type = AjaxResponseType.Error;
            }           
            return Json(ajaxResponse, JsonRequestBehavior.AllowGet);
        }
    }
}