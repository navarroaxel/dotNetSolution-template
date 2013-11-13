using System;

namespace Template.Core.Repositories
{
    public static class Persist
    {
        /// <summary>
        /// Persists the context after execute the action.
        /// </summary>
        /// <param name="action">The Action to be executed.</param>
        public static void It(Action action)
        {
            action();
            Repository.LocateIt<IPersistentRepository>().Persist();
        }

        /// <summary>
        /// Persists the context after execute the action.
        /// </summary>
        /// <typeparam name="T">The type returned by the Action.</typeparam>
        /// <param name="action">The Action<T> to be executed.</param>
        /// <returns>The value returned for the Action<T>.</returns>
        public static T It<T>(Func<T> action)
        {
            var value = action();
            Repository.LocateIt<IPersistentRepository>().Persist();
            return value;
        }
    }
}
