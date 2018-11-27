using System;
using Xunit;

namespace SpeakerMeet.DTO.Tests
{
    public class UserProfileDtoTests
    {
        [Fact]
        public void ItExists()
        {
            var dto = new UserProfileDto();
        }

        [Fact]
        public void ItHasAnId()
        {
            //Arrange
            var dto = new UserProfileDto();

            //Act
            dto.Id = 1;

            //Assert
            Assert.Equal(1, dto.Id);
        }



    }
}
