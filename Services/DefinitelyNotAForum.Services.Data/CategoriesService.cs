﻿using DefinitelyNotAForum.Data.Common.Repositories;
using DefinitelyNotAForum.Data.Models;
using DefinitelyNotAForum.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefinitelyNotAForum.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(
            IDeletableEntityRepository<Category> categoriesRepository
            )
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query =
                this.categoriesRepository.All().OrderBy(x => x.Name);
            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var category = this.categoriesRepository.All()
                .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
                .To<T>().FirstOrDefault();
            return category;
        }
    }
}
