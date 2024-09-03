using System.Data.Entity;

namespace b_PhotoFeed.DataAccess
{
    public interface IPhotoFeedContext
    {
        DbContext Context { get; }
        IDbSet<T> Set<T>() where T : class;
    }
}
