using GraphQlWebApi.Data;
using GraphQlWebApi.Mutations;
using GraphQlWebApi.Repositories;
using GraphQlWebApi.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Register Service
builder.Services.AddScoped<IProductService, ProductService>();

//InMemory Database
builder.Services.AddDbContext<ProjectContext>
(o => o.UseInMemoryDatabase("GraphQLDemo"));

//GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<ProductQueryTypes>()
    .AddMutationType<ProductMutations>();

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProjectContext>();
    SeedData.Initialize(services);
}

//GraphQL
app.MapGraphQL();

app.UseHttpsRedirection();

app.Run();
