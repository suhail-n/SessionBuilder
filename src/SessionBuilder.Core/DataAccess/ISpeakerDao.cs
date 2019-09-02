using System.Collections.Generic;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Core.DataAccess
{
    public interface ISpeakerDao : IStorage<Speaker>
    {
        ICollection<Speaker> FindAllSpeakers();
    }
}