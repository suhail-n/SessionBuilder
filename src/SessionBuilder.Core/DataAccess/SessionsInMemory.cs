using System;
using System.Collections.Generic;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Core.DataAccess
{
    public class SessionsInMemory
    {
        private static SessionsInMemory Instance = null;
        public static SessionsInMemory GetInstance()
        {
            if (SessionsInMemory.Instance == null)
            {
                SessionsInMemory.Instance = new SessionsInMemory();
            }
            return SessionsInMemory.Instance;
        }
        public ICollection<Session> Sessions { get; }
        private SessionsInMemory()
        {
            this.Sessions = new List<Session> {
                new Session
                {
                    Id = Guid.NewGuid(),
                    Title = "The state of C#",
                    Abstract = "In this talk I go through how C# has changed, as well as focusing on what's coming in C# 7.1, 7.2, 8.0 and beyond!",
                    Length = TimeSpan.FromMinutes(40),
                    // TimeSpan.FromHours is offset from UTC
                    SubmittedAt = new DateTimeOffset(2019, 09, 01, 01, 01, 00, TimeSpan.FromHours(1)),  // 2016-02-29 00:01:00.0000000 +01:00
                    ScheduledAt = new DateTimeOffset(2019, 10, 01, 09, 40, 00, TimeSpan.FromHours(2))   // 2019-08-01 09:40:00.0000000 +02:00
                },
                new Session
                {
                    Id = Guid.NewGuid(),
                    Title = "C# 8 and Beyond",
                    Abstract = "One of the most popular programming language on the market is getting even better. With every iteration of C# we get more and more features that are meant to make our lives as developers a lot easier. Join me in this session to explore what's new in C# 8, as well as what we can expect in the near (and far) future of C#!",
                    Length = TimeSpan.FromHours(1),
                    SubmittedAt = new DateTimeOffset(2016, 02, 29, 00, 00, 00, TimeSpan.FromHours(1)),  // 2016-02-29 00:00:00.0000000 +01:00
                    ScheduledAt = new DateTimeOffset(2019, 08, 01, 11, 01, 00, TimeSpan.FromHours(2))   // 2019-08-01 11:01:00.0000000 +02:00
                },
                new Session
                {
                    Id = Guid.NewGuid(),
                    Title = "Succeeding with Xamarin",
                    Abstract = "TBA",
                    Length = TimeSpan.FromMinutes(55),
                    SubmittedAt = new DateTimeOffset(2019, 01, 01, 00, 01, 00, TimeSpan.FromHours(1)),  // 2019-01-01 00:00:00.0000000 +01:00
                    ScheduledAt = new DateTimeOffset(2019, 08, 01, 12, 00, 00, TimeSpan.FromHours(2))   // 2019-08-01 12:00:00.0000000 +02:00
                },
                new Session
                {
                    Id = Guid.NewGuid(),
                    Title = "Using Dates and Times in .NET",
                    Abstract = "TBA",
                    Length = new TimeSpan(01, 45, 00),
                    SubmittedAt = new DateTimeOffset(2019, 01, 01, 00, 00, 00, TimeSpan.FromHours(1)),  // 2019-01-01 00:00:00.0000000 +01:00
                    ScheduledAt = new DateTimeOffset(2019, 08, 02, 09, 00, 00, TimeSpan.FromHours(2))   // 2019-08-02 09:00:00.0000000 +02:00
                }
            };
        }
    }
}