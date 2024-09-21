using Microsoft.Extensions.DependencyInjection;
using Streaming.STS;
using Streaming.STS.Data;
using Streaming.STS.GrantType;
using Streaming.STS.ProfileService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Carregando a configuração do banco.
builder.Services.Configure<DatabaseOption>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IIdentityRepository, IdentityRepository>();

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResource())
    .AddInMemoryApiResources(IdentityServerConfiguration.GetApiResource())
    .AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
    .AddInMemoryClients(IdentityServerConfiguration.GetClients())
    .AddProfileService<ProfileService>()
    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIdentityServer();

//tem que ser essa ordem
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
