using Xunit;
using SpeakerMeet.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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


        //Test exact match terms
        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection()
        {
            //Arrange
            
            //Act
            var result = _controller.Search("Joshua") as OkObjectResult;
            
            //Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Single(speakers);
            Assert.Equal("Joshua", speakers[0].Name);
        }

    }
}
