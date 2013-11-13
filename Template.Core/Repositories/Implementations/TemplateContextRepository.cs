using Template.Core.Model.Entities;

namespace Template.Core.Repositories.Implementations
{
    internal abstract class TemplateContextRepository
    {
        protected ITemplateContext Context { get; private set; }

        protected TemplateContextRepository(ITemplateContext context)
        {
            Context = context;
        }
    }
}
