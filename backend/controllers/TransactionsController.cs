using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly Supabase.Client _supabase;

    public TransactionsController(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = _supabase.From<Transaction>();
        var result = await query.Get();
        var dtos = new List<TransactionsDTO>();
        foreach (var t in result.Models)
        {
            dtos.Add(new TransactionsDTO
            {
                Id = t.Id,
                Date = t.Date,
                Description = t.Description,
                Amount = t.Amount,
                Category = t.Category,
                CreatedAt = t.CreatedAt
            });
        }
        return Ok(dtos);
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded");

        var transactions = new List<Transaction>();

        using var reader = new StreamReader(file.OpenReadStream());
        
        var headerLine = await reader.ReadLineAsync(); // skipping header
        
        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            var columns = line.Split(',');

            var transaction = new Transaction
            {
                Date = DateOnly.Parse(columns[0]),
                Description = columns[1],
                Amount = decimal.Parse(columns[2]),
                Category = columns[3]
            };

            transactions.Add(transaction);
        }

        await _supabase.From<Transaction>().Insert(transactions);

        return Ok(new { message = $"{transactions.Count} transactions imported" });
    }
}