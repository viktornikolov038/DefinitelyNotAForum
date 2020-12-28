namespace DefinitelyNotAForum.Web.ViewModels.Posts
{
    using System;

    using DefinitelyNotAForum.Data.Models;
    using DefinitelyNotAForum.Services.Mapping;
    using Ganss.XSS;

    public class PostCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }
    }
}
