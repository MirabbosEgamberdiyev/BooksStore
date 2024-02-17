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
}
