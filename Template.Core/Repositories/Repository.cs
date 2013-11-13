using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Repositories
{
    public static class Repository
    {
        public static TRepository LocateIt<TRepository>()
        {
            return RepositoryLocator.Current.Resolve<TRepository>();
        }

        public static void Clear()
        {
            RepositoryLocator.Clear();
        }
    }
}
