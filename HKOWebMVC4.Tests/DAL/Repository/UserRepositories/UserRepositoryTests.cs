using HKOWebMVC4.Models;
using Moq;
using NUnit.Framework;

namespace HKOWebMVC4.DAL.Repository.UserRepositories.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {

        UserRepository sut = new UserRepository();

        [Test]
        public void fetchUserByIdTest()
        {
            ApplicationUser user = sut.fetchUserByUPId(1);
            Assert.That(user.UserProfileInfo.Id, Is.EqualTo(1));
        }

        [Test]
        public void updateUserProfileInfoRealTest()
        {
            ApplicationUser user = sut.fetchUserByUPId(1);
            ApplicationUser newUser = user;
            newUser.UserProfileInfo.Ime = "Denis";
            user = sut.updateUserProfileInfo(user, newUser);
            Assert.That(user.UserProfileInfo.Ime, Is.EqualTo("Denis"));
        }

        [Test]
        public void returnTrueMockTest()
            // Ukoliko se želi koristiti Moq i Mockanje, metoda koja se poziva mora biti označena kao
            // virtual zbog Setup metode - Setup zahtjeva virtual da bi je mogla overridat
        {
            var mockedSUT = new Mock<UserRepository>();
            mockedSUT.Setup(u => u.returnTrue(It.IsAny<bool>())).Returns(false);
            bool result = mockedSUT.Object.returnTrue(true);
            Assert.That(result, Is.False);
        }

        //[TestMethod()]
        //public void fetchUserByUPIdTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void fetchCurrentUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void updateUserProfileInfoTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getSelectedProffesionForCurrentUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getSelectedProffesionsForUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void removeSelectedProffesionsForUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void setSelectedProffesionsForUserTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void fetchUsersByProffesionsListTest()
        //{
        //    Assert.Fail();
        //}
    }
}