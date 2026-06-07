var builder = WebApplication.CreateBuilder(args);

var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:Key"];

var supabase = new Supabase.Client(supabaseUrl, supabaseKey);
await supabase.InitializeAsync();

builder.Services.AddSingleton(supabase);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://budgeting-app-five-psi.vercel.app")              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.MapControllers();
app.Run();