
namespace Template.Core.Repositories
{
    public interface IRemoveRepository
    {
        void Remove<TEntity>(TEntity entity);
        void Remove<TEntity>(TEntity[] entities);
    }
}
