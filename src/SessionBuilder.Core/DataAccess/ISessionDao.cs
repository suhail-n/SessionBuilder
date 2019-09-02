using System.Collections.Generic;
using SessionBuilder.Core.Models;

namespace SessionBuilder.Core.DataAccess
{
    public interface ISessionDao : IStorage<Session>
    {
        ICollection<Session> FindAllSessions();
    }
}