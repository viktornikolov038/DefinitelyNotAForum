﻿namespace DefinitelyNotAForum.Services.Tests
{
    using System;
    using System.Threading.Tasks;

    using DefinitelyNotAForum.Data;
    using DefinitelyNotAForum.Data.Models;
    using DefinitelyNotAForum.Data.Repositories;
    using DefinitelyNotAForum.Services.Data;
    using DefinitelyNotAForum.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public void TestGetPostById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            var repository = new EfDeletableEntityRepository<Post>(new ApplicationDbContext(options.Options));
            repository.AddAsync(new Post { Title = "test" }).GetAwaiter().GetResult();
            repository.SaveChangesAsync().GetAwaiter().GetResult();
            var postService = new PostsService(repository);
            AutoMapperConfig.RegisterMappings(typeof(MyTestPost).Assembly);
            var post = postService.GetById<MyTestPost>(1);

            Assert.Equal("test", post.Title);
        }

        public class MyTestPost : IMapFrom<Post>
        {
            public string Title { get; set; }
        }

        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            var repository = new EfRepository<Vote>(new ApplicationDbContext(options.Options));
            var service = new VotesService(repository);

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "1", false);
            }

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "2", false);
            }

            var votes = service.GetVotes(1);
            Assert.Equal(-2, votes);
        }
    }
}
