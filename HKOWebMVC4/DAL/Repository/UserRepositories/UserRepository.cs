using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HKOWebMVC4.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using HKOWebMVC4.Models.HKOWebModels.ExceptionModels;

namespace HKOWebMVC4.DAL.Repository.UserRepositories
{
    public class UserRepository
    {
        #region members
        private static HKO_WEB dbContext = new HKO_WEB();
        private static UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(dbContext);
        private static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
        private HKOPodaciService.HKOPodaciService HKOPodaci = new HKOPodaciService.HKOPodaciService();
        #endregion

        #region methods
        public ApplicationUser fetchUserById(string userId)
        {
            try
            {
                return userManager.FindById(userId);
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Dohvat korisnika po ID-u nije uspio! Razlog:\n" + tException.Message);
            }
        }

        public ApplicationUser fetchUserByUPId(int userProfileId)
        {
            ApplicationUser user = dbContext.Users.Where(u => u.UserProfileInfo.Id == userProfileId).First();
            return user;
        }

        public ApplicationUser fetchCurrentUser()
        {
            try
            {
                ApplicationUser user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());
                return user;
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Dohvat trenutnog korisnika nije uspio! Razlog:\n" + tException.Message);
            }
        }

        public ApplicationUser updateUserProfileInfo(ApplicationUser user, ApplicationUser newUser)
        {
            try
            { 
                user.UserProfileInfo.Ime = newUser.UserProfileInfo.Ime;
                user.UserProfileInfo.Prezime = newUser.UserProfileInfo.Prezime;
                user.UserProfileInfo.JMBAG = newUser.UserProfileInfo.JMBAG;
                user.UserProfileInfo.Država = newUser.UserProfileInfo.Država;
                user.UserProfileInfo.Grad = newUser.UserProfileInfo.Grad;
                user.UserProfileInfo.Adresa = newUser.UserProfileInfo.Adresa;
                dbContext.UserProfileInfo.Attach(user.UserProfileInfo);
                dbContext.Entry(user.UserProfileInfo).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return user;
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Izmjena podataka korisnika nije uspjela! Razlog:\n" + tException.Message);
            }
        }

        public List<KorisnikOdabranaZanimanja> getSelectedProffesionForCurrentUser()
        {
            try
            {
                var currentUser = fetchCurrentUser().UserProfileInfo;
                var poZanimanjaList = getSelectedProffesionsForUser(currentUser);
                return poZanimanjaList;
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Dohvat odabranih zanimanja za trenutnog korisnika nije uspio! Razlog:\n" + tException.Message);
            }
        }

        public List<KorisnikOdabranaZanimanja> getSelectedProffesionsForUser(UserProfileInfo user)
        {
            try
            {
                var poZanimanjaList = dbContext.KorisnikOdabranaZanimanja.Where(p => p.userProfile.Id == user.Id).ToList();
                return poZanimanjaList;
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Dohvat odabranih zanimanja za određenog korisnika nije uspio! Razlog:\n" + tException.Message);
            }
        }

        public void removeSelectedProffesionsForUser(UserProfileInfo user)
        {
            try
            {
                dbContext.KorisnikOdabranaZanimanja.RemoveRange(getSelectedProffesionsForUser(user));
                dbContext.SaveChanges();
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Brisanje odabranih zanimanja za korisnika nije uspjelo! Razlog:\n" + tException.Message);
            }
        }

        public void setSelectedProffesionsForUser(List<KorisnikOdabranaZanimanja> proffesionsList, UserProfileInfo user)
        {
            foreach(KorisnikOdabranaZanimanja odabranoZanimanje in proffesionsList)
            {
                odabranoZanimanje.userProfile = user;
            }
            try
            {
                dbContext.KorisnikOdabranaZanimanja.AddRange(proffesionsList);
                dbContext.SaveChanges();
            }
            catch (Exception tException)
            {
                throw new HKOWebRuntimeException("Spremanje odabranih zanimanja za korisnika nije uspjelo! Razlog:\n" + tException.Message);
            }
        }

        public List<UserProfileInfo> fetchUsersByProffesionsList(List<KorisnikOdabranaZanimanja> wantedProffesions)
        {
            List<int> proffesionsIdList = new List<int>();
            foreach(KorisnikOdabranaZanimanja zanimanje in wantedProffesions)
            {
                proffesionsIdList.Add(zanimanje.zanimanjeId);
            }
            var query = dbContext.KorisnikOdabranaZanimanja;
            var userList =query.Where(o => proffesionsIdList.Contains(o.zanimanjeId))
                .Select(o => o.userProfile).Distinct().ToList() ;
            return userList;
        }

        // Radi oglednog primjerka u testu
        // Moq može mockati samo virtual metode preko Setup
        public virtual bool returnTrue(bool krivo)
        {
            return krivo;
        }

        #endregion
    }
}