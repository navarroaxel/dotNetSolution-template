using System;
using System.Transactions;

namespace Template.Core.Repositories
{
    public static class Transact
    {
        public static void It(Action action)
        {
            using (var scope = new TransactionScope())
            {
                action();
                scope.Complete();
            }
        }

        public static T It<T>(Func<T> action)
        {
            using (var scope = new TransactionScope())
            {
                var value = action();
                scope.Complete();
                return value;
            }
        }

        public static void ItWithNoLock(Action action)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            {
                action();
                scope.Complete();
            }
        }

        public static T ItWithNoLock<T>(Func<T> action)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            {
                var value = action();
                scope.Complete();
                return value;
            }
        }
    }
}
