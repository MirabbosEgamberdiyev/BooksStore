namespace BooksStore.InventoryService.Data.Entiteis;

public class Book : BaseEntity
{
    public string Tetle { get; set; } = string.Empty;
    public string Auther { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public int Year { get; set; }
    public int Pages { get; set; }
    public string Language { get; set; } = string.Empty;
    public decimal Barecode { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> CategoryId { get; set; } = new();


}
