using Acme.ProductApp.Categories;
using Acme.ProductApp.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.ProductApp
{
    public class CategoryDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        //get interface repository of category
        public CategoryDataSeederContributor(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        //using seedasync to seeder data into table
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.GetCountAsync() <= 0)
            {
                //insert items to table
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                       Title = "A",
                       
                    },
                    autoSave: true
                );
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        Title = "B",

                    },
                    autoSave: true
                );
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        Title = "C",

                    },
                    autoSave: true
                );
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        Title = "D",

                    },
                    autoSave: true
                );


            }
        }
    }
}
