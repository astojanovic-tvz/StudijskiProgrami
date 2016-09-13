using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;

namespace HKOWebMVC4.Controllers.Tests
{
    [TestFixture]
    public class ManageControllerTests
    {

        [Test]
        [Ignore("User manager error not solved")]
        public void IndexTest()
        {
            // Arrange
            ManageController controllerSUT = new ManageController();

            // Act
            Task<ActionResult> result = controllerSUT.Index(ManageController.ManageMessageId.AddPhoneSuccess, 1) as Task<ActionResult>;

            // Assert
            var resultRes = result.Result;

            //Assert.AreEqual("Your application description page.", result.Result  ViewBag.StatusMessage)
            Assert.NotNull(resultRes);
            //Assert.Fail();
        }
    }
}