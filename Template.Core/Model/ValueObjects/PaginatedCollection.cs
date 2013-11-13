
namespace Template.Core.Model.ValueObjects
{
    public class PaginatedCollection<T>
    {
        public T[] Collection { get; set; }
        public Page Page { get; set; }
        public int TotalRows { get; set; }
        public int QuantityPages { get; set; }
    }
}
