using BooksStore.InventoryService.Data.Entiteis;
using BooksStore.InventoryService.Models;

namespace BooksStore.InventoryService.Data.Interfaces;

public interface ICategoryInterface
{
    Task<IEnumerable<Category>> GetCategories();
    Task<Category> GetCategory(string id);
    Task<Category> AddCategory(AddCategory addCategory);
    Task<Category> UpdateCategory(Category category);
    Task<Category> DeleteCategory(string id);

}
