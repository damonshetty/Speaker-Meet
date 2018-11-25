using SpeakerMeet.DTO;
using System.Collections.Generic;

namespace SpeakerMeet.Services.Interfaces
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> Search(string searchString);
    }
}
