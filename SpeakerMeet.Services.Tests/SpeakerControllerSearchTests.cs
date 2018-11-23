using Xunit;
using SpeakerMeet.API.Controllers;

namespace SpeakerMeet.Services.Tests
{
    public class SpeakerControllerSearchTests
    {   
        //[Fact]
        //public void ItExists()
        //{
        //    var controller = new SpeakerMeetController();
        //}

        
        [Fact]
        public void ItHasSearch()
        {
            //Arrange
            var controller = new SpeakerController();
            
            //Act
            var result = controller.Search("Jos");
        }


        [Fact]
        public void ItReturnsOkObjectResult()
        {
            //Arrange
            var controller = new SpeakerController();

            //Act
            var result = controller.Search("Jos");

            //Assert
            Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result);
        }

    }
}
