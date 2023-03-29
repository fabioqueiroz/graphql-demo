using GraphiQl;
using GraphQL.Demo.Data;
using GraphQL.Demo.Data.Access;
using GraphQL.Demo.Data.Access.Queries;
using GraphQL.Demo.Data.Access.Schema;
using GraphQL.Demo.Data.Interfaces;
using GraphQL.Demo.Data.Repositories;
using GraphQL.Demo.Entities.Types;
using GraphQL.Demo.Services.Interfaces;
using GraphQL.Demo.Services.Product;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<IProductService,ProductService>()
    .AddScoped<IProductRepository, ProductRepository>();

// GraphQL 
builder.Services.AddGraphQLServices();

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;

}).AddSystemTextJson();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    opts =>
    {
        opts.EnableRetryOnFailure((int)TimeSpan.FromSeconds(5).TotalSeconds);
        opts.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseHttpsRedirection();

//app.UseAuthorization();
//app.MapControllers();

app.Run();

