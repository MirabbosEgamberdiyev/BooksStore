﻿using MongoDB.Bson.Serialization.Attributes;

namespace BooksStore.InventoryService.Data.Entiteis;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
}
