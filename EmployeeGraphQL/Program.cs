using EmployeeGraphQL.Data;
using EmployeeGraphQL.GraphQL.Mutations;
using EmployeeGraphQL.GraphQL.Queries;
using EmployeeGraphQL.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<EmployeeType>();

// Configurar CORS para permitir todas as origens
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseCors(); // Adicione esta linha para usar a configuração de CORS

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

// Adicione o Playground para testar o GraphQL
//app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
//{
//    Path = "/playground"
//});

app.Run();
