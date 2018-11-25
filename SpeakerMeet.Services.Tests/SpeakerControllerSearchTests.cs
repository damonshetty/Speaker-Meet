using Xunit;
using SpeakerMeet.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SpeakerMeet.Services.Interfaces;
using Moq;
using SpeakerMeet.DTO;

namespace SpeakerMeet.API.Tests
{
    public class SpeakerControllerSearchTests
    {
        private readonly SpeakerController _controller;
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<Speaker> _speakers;

        public SpeakerControllerSearchTests()
        {
            _speakers = new List<Speaker> { new Speaker
            {
                Name = "test"
            } };

            // define the mock
            _speakerServiceMock = new Mock<ISpeakerService>();

            // when search is called, return list of speakers containing speaker
            _speakerServiceMock.Setup(x => x.Search(It.IsAny<string>()))
                .Returns(() => _speakers);


            _controller = new SpeakerController(_speakerServiceMock.Object);
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


        //Ensure search is not case senstitive
        [Fact]
        public void GivenCaseInsensitiveMatchThenSpeakerInCollection()
        {
            //Arrange
            
            //Act
            var result = _controller.Search("joshua") as OkObjectResult;

            //Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Single(speakers);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        //Check what happens if no match - is an empty collection returned?
        public void GivenNoMatchThenEmptyCollection()
        {
            //Arrange
            
            //Act
            var result = _controller.Search("ZZZ") as OkObjectResult;

            //Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Empty(speakers);
            Assert.Equal(0, speakers.Count);
        }

        //Test multiple results returned if begins with search term
        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            //Act
            var result = _controller.Search("jos") as OkObjectResult;

            //Assert
            var speakers = ((IEnumerable<Speaker>)result.Value).ToList();
            Assert.Equal(3, speakers.Count);
            Assert.Contains(speakers, s => s.Name == "Josh");
            Assert.Contains(speakers, s => s.Name == "Joshua");
            Assert.Contains(speakers, s => s.Name == "Joseph");

        }


        [Fact]
        public void ItAcceptsService()
        {
            //Arrange
            ISpeakerService testSpeakerService = new TestSpeakerService();

            //Act
            var controller = new SpeakerController(testSpeakerService);

            //Assert
            Assert.NotNull(controller);

        }

    }
}
