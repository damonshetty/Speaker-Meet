using Xunit;
using SpeakerMeet.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SpeakerMeet.Services.Tests
{
    public class SpeakerControllerSearchTests
    {
        [Fact]
        public void ItExists()
        {
            var controller = new SpeakerController();
        }
        
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
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            //Arrange
            var controller = new SpeakerController();

            //Act
            var result = controller.Search("Jos") as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Speaker>>(result.Value);
        }

    }
}
