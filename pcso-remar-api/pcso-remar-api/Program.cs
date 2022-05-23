using pcso_remar_api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

MessageManager messageManager = new MessageManager();

app.MapGet("Hello", () => "This is very cool I hope");
app.MapGet("Product", () => "Get some Product from Azure SQL");

app.MapPost("Product", (Product p) => "Product saved in SQL");
app.MapDelete("Product", (string name) => "Deleted");


app.MapGet("Chat", () => messageManager.Messages);
app.MapPost("Chat", (Message msg) => messageManager?.Messages?.Add(msg));

app.Run();

// Some Data Contracts
public record class Message(string Name, string Msg);
public record class Product(string Name, string Picture, int Price);