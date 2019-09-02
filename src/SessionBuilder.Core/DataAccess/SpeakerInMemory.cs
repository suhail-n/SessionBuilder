using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Core.DataAccess
{
    public class SpeakerInMemory
    {
        private static SpeakerInMemory Instance = null;
        public static SpeakerInMemory GetInstance()
        {
            if (SpeakerInMemory.Instance == null)
            {
                SpeakerInMemory.Instance = new SpeakerInMemory();
            }
            return SpeakerInMemory.Instance;

        }
        public IEnumerable<Speaker> Speakers { get; }
        private SpeakerInMemory()
        {
            this.Speakers = new List<Speaker> {
                new Speaker
                {
                    Id = Guid.NewGuid(),
                    Name = "Filip Ekberg",
                    Birthday = new DateTime(1990, 09, 30),
                    Sessions = SessionsInMemory.GetInstance().Sessions
                }
            };
        }
    }
}