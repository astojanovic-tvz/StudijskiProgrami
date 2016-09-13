using HKOWebMVC4.DAL.Repository.UserRepositories;
using HKOWebMVC4.Models;
using HKOWebMVC4.Models.HKOWebModels.AjaxModels;
using HKOWebMVC4.Models.HKOWebModels.ExceptionModels;
using HKOWebMVC4.Models.HKOWebModels.Korisnik;
using System.Collections.Generic;

namespace HKOWebMVC4.DAL.Repository.UserServices
{
    public class UserService
    {
        private static UserRepository userRepo = new UserRepository();
        private _AjaxResponseModel ajaxResponse = new _AjaxResponseModel();
        public ApplicationUser fetchUserById(string userId)
        {
            return userRepo.fetchUserById(userId);
        }

        public ApplicationUser fetchUserByUPId(int userProfileId)
        {
            return userRepo.fetchUserByUPId(userProfileId);
        }

        public ApplicationUser fetchCurrentUser()
        {
            return userRepo.fetchCurrentUser();
        }

        public ApplicationUser updateUserProfileInfo(ApplicationUser user, ApplicationUser newUser)
        {
            return userRepo.updateUserProfileInfo(user, newUser);
        }

        public List<KorisnikOdabranaZanimanja> getSelectedProffesionForCurrentUser()
        {
            return userRepo.getSelectedProffesionForCurrentUser();
        }

        public List<KorisnikOdabranaZanimanja> getSelectedProffesionsForUser(UserProfileInfo user)
        {
            return userRepo.getSelectedProffesionsForUser(user);
        }

        public _AjaxResponseModel removeSelectedProffesionsForUser(UserProfileInfo user)
        {
            try
            {
                userRepo.removeSelectedProffesionsForUser(user);
                ajaxResponse.message = "Korisnikova odabrana zanimanja su pobrisana!"; 
            }
            catch (HKOWebRuntimeException tException)
            {
                ajaxResponse.message = tException.Message;
                ajaxResponse.type = AjaxResponseType.Error; 
            }
            return ajaxResponse;
        }

        public _AjaxResponseModel setSelectedProffesionsForUser(List<KorisnikOdabranaZanimanja> odabranaZanimanja, UserProfileInfo user)
        {
            try
            {
                userRepo.setSelectedProffesionsForUser(odabranaZanimanja, user);
                ajaxResponse.message = "Odabrana zanimanja uspješno postavljena!";
            }
            catch (HKOWebRuntimeException tException)
            {
                ajaxResponse.message = tException.Message;
                ajaxResponse.type = AjaxResponseType.Error;
            }
            return ajaxResponse;
        }

        public List<UserProfileInfo> fetchUsersByProffesionsList(List<KorisnikOdabranaZanimanja> odabranaZanimanja)
        {
            return userRepo.fetchUsersByProffesionsList(odabranaZanimanja);
        } 
    }
}
