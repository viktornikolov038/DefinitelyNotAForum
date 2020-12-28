namespace DefinitelyNotAForum.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DefinitelyNotAForum.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Technology", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBQXfpLkU0sWkgfkyy_2YpelS-7Mu3PReqWA&usqp=CAU"),
                ("World news", "https://pbs.twimg.com/profile_images/643694074/globe-europe_400x400.jpg"),
                ("Sports", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFeHDOaxdXpHFUb5XuNE2_sPDIq-GFZXhsww&usqp=CAU"),
                ("Video games", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSVx2jUivaHzNFzyVO2gHbuMoeqnlnQrSPyA&usqp=CAU"),
                ("Animals", "https://images.theconversation.com/files/285143/original/file-20190722-11355-1peled7.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=926&fit=clip"),
                ("Memes", "https://cdn3.f-cdn.com/contestentries/1451126/30684613/5bf9f5530f3a0_thumb900.jpg"),
                ("Cars", "https://images-na.ssl-images-amazon.com/images/I/71%2BmhWHnBdL._SL1500_.jpg"),
                ("Movies", "https://kinoto.bg/media/app_large/uploads/BG-cinema/rent_a_hall-2.jpg"),
            };
            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
