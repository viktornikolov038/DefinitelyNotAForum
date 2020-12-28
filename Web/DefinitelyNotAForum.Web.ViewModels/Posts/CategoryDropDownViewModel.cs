namespace DefinitelyNotAForum.Web.ViewModels.Posts
{
    using DefinitelyNotAForum.Data.Models;
    using DefinitelyNotAForum.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
