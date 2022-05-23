var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    app.MapGet("Hello", () => "This is very cool I hope");
    app.MapGet("Product", () => "Get some Product from Azure SQL");
    app.MapPost("Product", (Product p) => "Prodcut saved in SQL");
    app.MapPost("Chat", (Message msg) => "Message posted to chat SQL");

app.Run();

// Some Data Contracts
public record class Message(string Name, string Msg);
public record class Product(string Name, string Picture, int Price);