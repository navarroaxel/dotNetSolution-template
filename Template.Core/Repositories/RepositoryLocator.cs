using System;
using Autofac;

namespace Template.Core.Repositories
{
    class RepositoryLocator
    {
        private static RepositoryLocator current;
        public static object _sync = new Object();

        public static RepositoryLocator Current
        {
            get
            {
                if (current == null)
                {
                    lock (_sync)
                    {
                        if (current == null)
                        {
                            current = new RepositoryLocator(RepositoriesContainer.RegisterServices());
                        }
                    }
                }
                return current;
            }
            set { current = value; }
        }

        private IContainer Container { get; set; }

        public RepositoryLocator(IContainer container)
        {
            Container = container;
        }

        public TRepository Resolve<TRepository>()
        {
            if (Container.IsRegistered<TRepository>())
                return Container.Resolve<TRepository>();

            return default(TRepository);
        }

        public static void Clear()
        {
            Current.Resolve<Model.Entities.TemplateContext>().Dispose();
            current = null;
        }
    }
}
