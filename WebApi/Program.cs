using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Service.CategoryService;
using WebApi.Service.OrderItemService;
using WebApi.Service.OrderService;
using WebApi.Service.ProductService;
using WebApi.Service.ReviewService;
using WebApi.Service.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IReviewService, ReviewService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IOrderItemService, OrderItemService>();


// подключение к БД через Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
