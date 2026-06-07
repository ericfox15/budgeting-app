using Postgrest.Attributes;
using Postgrest.Models;

[Table("transactions")]
public class Transaction : BaseModel
{
    [PrimaryKey("id")]
    public string Id { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("category")]
    public string Category { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}