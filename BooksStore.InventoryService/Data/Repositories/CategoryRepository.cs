using BooksStore.InventoryService.Data.Entiteis;
using BooksStore.InventoryService.Data.Interfaces;
using BooksStore.InventoryService.Models;

namespace BooksStore.InventoryService.Data.Repositories;

public class CategoryRepository(InventoryDatabase database) : ICategoryInterface
{
    private readonly InventoryDatabase _database = database;

    public Task<Category> AddCategory(AddCategory addCategory)
    {
       var result = _database.Categories.InsertOneAsync(new Category()
        {
            Name = addCategory.name
        });

        return (Task<Category>)result;
    }

    public Task<Category> DeleteCategory(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategory(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> UpdateCategory(Category category)
    {
        throw new NotImplementedException();
    }
}
