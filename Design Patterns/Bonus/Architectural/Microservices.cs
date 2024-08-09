// ProductService/Program.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();

// ProductService/Controllers/ProductController.cs
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Smartphone", Price = 599.99m }
    };

  [HttpGet]
  public IActionResult GetAll() => Ok(_products);

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var product = _products.Find(p => p.Id == id);
    if (product == null) return NotFound();
    return Ok(product);
  }
}

public class Product
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }
}

// OrderService/Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.Run();

// OrderService/Controllers/OrderController.cs
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
  private static readonly List<Order> _orders = new();
  private static int _nextId = 1;

  [HttpPost]
  public IActionResult Create(Order order)
  {
    order.Id = _nextId++;
    _orders.Add(order);
    return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var order = _orders.Find(o => o.Id == id);
    if (order == null) return NotFound();
    return Ok(order);
  }
}

public class Order
{
  public int Id { get; set; }
  public int ProductId { get; set; }
  public int Quantity { get; set; }
}

// ApiGateway/Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
var app = builder.Build();

app.MapGet("/products", async (HttpContext context, IHttpClientFactory clientFactory) =>
{
  var client = clientFactory.CreateClient();
  var response = await client.GetAsync("http://localhost:5001/api/product");
  context.Response.StatusCode = (int)response.StatusCode;
  await response.Content.CopyToAsync(context.Response.Body);
});

app.MapPost("/orders", async (HttpContext context, IHttpClientFactory clientFactory) =>
{
  var client = clientFactory.CreateClient();
  var response = await client.PostAsync("http://localhost:5002/api/order", context.Request.Body);
  context.Response.StatusCode = (int)response.StatusCode;
  await response.Content.CopyToAsync(context.Response.Body);
});

app.Run();