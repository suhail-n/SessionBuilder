namespace SessionBuilder.Core.DataAccess
{
    public interface IStorage<T> where T : IStoreable
    {
        T Create(T t);
        bool Delete(T t);
        T Update(T t);
    }
}