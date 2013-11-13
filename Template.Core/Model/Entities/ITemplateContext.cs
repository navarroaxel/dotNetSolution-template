using System.Data.Entity;

namespace Template.Core.Model.Entities
{
    public interface ITemplateContext
    {
        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
