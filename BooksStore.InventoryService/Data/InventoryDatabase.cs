using BooksStore.InventoryService.Data.Entiteis;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Driver;

namespace BooksStore.InventoryService.Data;

public class InventoryDatabase
{
    public IMongoDatabase  mongoDatabase { get; set; }
    public InventoryDatabase(string connectionString, string databaseName)
    {
        var connection = new MongoClient(connectionString);
        mongoDatabase = connection.GetDatabase(databaseName);
    }
    public IMongoCollection<Category> Categories =>
        mongoDatabase.GetCollection<Category>("Categories");
    public IMongoCollection<Book> Books =>
        mongoDatabase.GetCollection<Book>("Books");
}
