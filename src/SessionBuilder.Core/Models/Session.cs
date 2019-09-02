using System;
using SessionBuilder.Core.DataAccess;

namespace SessionBuilder.Core.Models
{
    public class Session : IStoreable
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Abstract { get; set; }
        public TimeSpan Length { get; set; }
        public DateTimeOffset SubmittedAt { get; set; }
        public DateTimeOffset ScheduledAt { get; set; }
        public bool Deleted { get; set; }

        public Session()
        {
            this.Deleted = false;
        }
    }
}