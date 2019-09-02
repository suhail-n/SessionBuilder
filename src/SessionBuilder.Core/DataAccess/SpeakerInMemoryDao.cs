using System;
using System.Linq;
using System.Collections.Generic;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Core.DataAccess
{
    public class SpeakerInMemoryDao : ISpeakerDao
    {
        public Speaker Create(Speaker t)
        {
            t.Id = new Guid();
            SpeakerInMemory.GetInstance().Speakers.Append(t);
            return t;
        }

        public bool Delete(Speaker t)
        {
            var speaker = SpeakerInMemory.GetInstance().Speakers.FirstOrDefault(s => s.Id == t.Id);
            if (speaker == null) return false;

            speaker.Deleted = true;
            return true;
        }

        public ICollection<Speaker> FindAllSpeakers()
        {
            return (ICollection<Speaker>)SpeakerInMemory.GetInstance().Speakers;
        }

        public Speaker Update(Speaker t)
        {
            var speaker = SpeakerInMemory.GetInstance().Speakers.FirstOrDefault(s => s.Id == t.Id);
            if (speaker == null) return null;
            speaker.Birthday = t.Birthday;
            speaker.Deleted = t.Deleted;
            speaker.Name = t.Name;
            speaker.Sessions = t.Sessions;
            return speaker;
        }
    }
}