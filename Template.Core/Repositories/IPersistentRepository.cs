
namespace Template.Core.Repositories
{
    public interface IPersistentRepository
    {
        /// <summary>
        /// Saves the changes made in the context.
        /// </summary>
        void Persist();
    }
}
