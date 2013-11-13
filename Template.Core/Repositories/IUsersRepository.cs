using Template.Core.Model.Entities;

namespace Template.Core.Repositories
{
    public interface IUsersRepository
    {
        /// <summary>
        /// Adds a new user to the context.
        /// </summary>
        /// <param name="user">A user to be added to the context.</param>
        void Add(User user);

        /// <summary>
        /// Finds the User by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user with the searched ID or a null if does not exist.</returns>
        User Get(int id);
    }
}
