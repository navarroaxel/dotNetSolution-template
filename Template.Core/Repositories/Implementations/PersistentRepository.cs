using System.Data.Entity.Validation;
using System.Diagnostics;
using Template.Core.Model.Entities;

namespace Template.Core.Repositories.Implementations
{
    class PersistentRepository : TemplateContextRepository, IPersistentRepository
    {
        public PersistentRepository(ITemplateContext context)
            : base(context) { }

        void IPersistentRepository.Persist()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in validationErrors.ValidationErrors)
                    {
                        Trace.TraceError("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
