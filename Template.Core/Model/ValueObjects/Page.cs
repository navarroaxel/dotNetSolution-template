
namespace Template.Core.Model.ValueObjects
{
    public class Page
    {
        public static Page Default = new Page { Number = 1, Size = 20 };

        public int Number { get; set; }
        public int Size { get; set; }
    }
}
