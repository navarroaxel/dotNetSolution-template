using System;
using System.Data.Entity.Infrastructure;
using Template.Core.Model.Entities;

namespace Template.Core.Repositories.Implementations
{
    class RemoveRepository : TemplateContextRepository, IRemoveRepository
    {
        public RemoveRepository(ITemplateContext context)
            : base(context) { }

        void IRemoveRepository.Remove<TEntity>(TEntity entity)
        {
            ((IObjectContextAdapter)Context).ObjectContext.DeleteObject(entity);
        }

        void IRemoveRepository.Remove<TEntity>(TEntity[] entities)
        {
            var objContext = ((IObjectContextAdapter)Context).ObjectContext;
            Array.ForEach(entities, e => objContext.DeleteObject(e));
        }
    }
}
