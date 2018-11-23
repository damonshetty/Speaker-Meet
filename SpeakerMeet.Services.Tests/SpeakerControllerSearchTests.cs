using Xunit;
using SpeakerMeet.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SpeakerMeet.Services.Tests
{
    public class SpeakerControllerSearchTests
    {
        private readonly SpeakerController _controller;

        public SpeakerControllerSearchTests()
        {
            _controller = new SpeakerController();
        }
        
        [Fact]
        public void ItHasSearch()
        {
            //Arrange

            
            //Act
            var result = _controller.Search("Jos");
        }
        
        [Fact]
        public void ItReturnsOkObjectResult()
        {
            //Arrange

            //Act
            var result = _controller.Search("Jos");

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            //Arrange

            //Act
            var result = _controller.Search("Jos") as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Speaker>>(result.Value);
        }

    }
}
