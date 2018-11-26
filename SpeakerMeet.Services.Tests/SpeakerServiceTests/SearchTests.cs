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




    }



}
