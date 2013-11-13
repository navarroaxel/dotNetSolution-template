using Autofac;
using Template.Core.Model.Entities;
using Template.Core.Repositories.Implementations;

namespace Template.Core.Repositories
{
    static class RepositoriesContainer
    {
        public static IContainer RegisterServices()
        {
            var container = new ContainerBuilder();

            container.Register(x => new TemplateContext()).SingleInstance();

            container.Register(x => new PersistentRepository(x.Resolve<TemplateContext>())).As<IPersistentRepository>();
            container.Register(x => new RemoveRepository(x.Resolve<TemplateContext>())).As<IRemoveRepository>();

            // Register here all the repositories.
            container.Register(x => new UsersRepository(x.Resolve<TemplateContext>())).As<IUsersRepository>();

            return container.Build();
        }
    }
}
