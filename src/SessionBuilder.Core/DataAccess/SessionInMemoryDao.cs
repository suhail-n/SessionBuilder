using System.Linq;
using System;
using System.Collections.Generic;
using SessionBuilder.Core.Models;
using SessionBuilder.Core.DataAccess;

namespace SessionBuilder.Core.DataAccess
{
    public class SessionInMemoryDao : ISessionDao
    {
        public Session Create(Session t)
        {
            t.Id = new Guid();
            SessionsInMemory.GetInstance().Sessions.Append(t);
            return t;
        }

        public bool Delete(Session t)
        {
            var sess = SessionsInMemory.GetInstance().Sessions.FirstOrDefault(session => session.Id == t.Id);
            if (sess == null) return false;

            sess.Deleted = true;
            return true;
        }

        public ICollection<Session> FindAllSessions()
        {
            return (ICollection<Session>)SessionsInMemory.GetInstance().Sessions;
        }

        public Session Update(Session t)
        {
            var session = SessionsInMemory.GetInstance().Sessions.FirstOrDefault(sess => sess.Id == t.Id);
            if (session == null) return null;
            session.Abstract = t.Abstract;
            session.Deleted = t.Deleted;
            session.Length = t.Length;
            session.ScheduledAt = t.ScheduledAt;
            session.SubmittedAt = t.SubmittedAt;
            session.Title = t.Title;
            return session;
        }
    }
}