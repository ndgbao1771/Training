using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Training.Model;
using Training.Repository;
using Training.Repository.BookWarehouseRepository;
using Training.Repository.Interfaces;
using Training.Repository.Interfaces.BookWarehouse;
using Training.Service.Automap;
using Training.Service.Implement;
using Training.Service.Implement.BookWarehouse;
using Training.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("connection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection, o => o.MigrationsAssembly("Training.Model")));

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookCategoryService, BookCategoryService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ILibrarianService, LibrarianService>();
builder.Services.AddTransient<IOrderDetailService, OrderDetailService>();

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();
builder.Services.AddTransient<IBookDetailRepository, BookDetailRepository>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ILibrarianRepository, LibrarianRepository>();
builder.Services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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