using System;
using System.Collections.Generic;
using SessionBuilder.Core.DataAccess;

namespace SessionBuilder.Core.Models
{
    public class Speaker : IStoreable
    {
        public Guid Id { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public String Name { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public bool Deleted { get; set; }

        public Speaker()
        {
            this.Deleted = false;
        }
    }
}