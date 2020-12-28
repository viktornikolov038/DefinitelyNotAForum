namespace DefinitelyNotAForum.Web.ViewModels.Home
{
    using AutoMapper;
    using DefinitelyNotAForum.Data.Models;
    using DefinitelyNotAForum.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/DefinetlyNot/{this.Name.Replace(' ', '-')}";
    }
}