using System.Linq;
using SpeakerMeet.Services.Interfaces;
using Xunit;
using SpeakerMeet.Services;
using System.Collections;
using System.Collections.Generic;
using SpeakerMeet.DTO;

namespace SpeakerMeet.Services.Tests.SpeakerServiceTests
{
   public class SearchTests
    {
        private readonly SpeakerService _speakerService;

        public SearchTests()
        {
            _speakerService = new SpeakerService();
        }

        [Fact] 
        public void ItExists()
        {
            var speakerService = new SpeakerService();
        }
        
        //Check search method exists
        [Fact]
        public void ItHasSearchMethod()
        {
            var speakerService = new SpeakerService();

            speakerService.Search("test");
        }


        //Check search returns a collection of speakers
        [Fact]
        public void GivenSearchTermReturnCollectionOfSpeakers()
        {
            //Arrange
            var speakerService = new SpeakerService();
            //Act
            var result = speakerService.Search("test");

            //Assert
            Assert.IsType<List<Speaker>>(result);
        }

        //Test if SpeakerService implements the ISpeakerService interface
        [Fact]
        public void ItImplementsISpeakerInterface()
        {
            //Act
            var speakerService = new SpeakerService();

            //Assert
            Assert.True(speakerService is ISpeakerService);
        }

        //Test exact match terms
        [Fact]
        public void GivenExactMatchThenOneSpeakerInCollection()
        {
            //Arrange

            //Act
            var result = _speakerService.Search("Joshua");

            //Assert
            var speakers = result.ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Single(speakers);
            Assert.Equal("Joshua", speakers[0].Name);
        }
        
        [Theory]
        [InlineData("Joshua")]
        [InlineData("joshua")]
        [InlineData("joshUa")]
        public void GivenCaseInsensitiveMatchThenSpeakerInCollection(string searchTerm)
        {
            //Arrange

            //Act
            var result = _speakerService.Search(searchTerm);

            //Assert
            var speakers = result.ToList();
            Assert.Equal(1, speakers.Count);
            Assert.Single(speakers);
            Assert.Equal("Joshua", speakers[0].Name);
        }


        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            //Arrange

            //Act
            var result = _speakerService.Search("ZZZ");

            //Assert
            var speakers = result.ToList();
            Assert.Empty(speakers);
            Assert.Equal(0, speakers.Count);
        }


        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            //Act
            var result = _speakerService.Search("jos");

            //Act
            var speakers = result.ToList();

            //Assert
            Assert.Equal(3, speakers.Count);
            Assert.Contains(speakers, s => s.Name == "Josh");
            Assert.Contains(speakers, s => s.Name == "Joshua");
            Assert.Contains(speakers, s => s.Name == "Joseph");
        }

    }



}
