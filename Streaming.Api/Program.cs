using Microsoft.EntityFrameworkCore;
using Streaming.Application.Conta;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Profile;
using Streaming.Application.Transacao;
using Streaming.Repository;
using Streaming.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StreamingContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("StreamingConnection"));
});

builder.Services.AddAutoMapper(typeof(ArtistaProfile).Assembly);

//Repositories
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<ArtistaRepository>();
builder.Services.AddScoped<AssinaturaRepository>();
builder.Services.AddScoped<BandeiraRepository>();
builder.Services.AddScoped<CartaoRepository>();
builder.Services.AddScoped<CompositorRepository>();
builder.Services.AddScoped<FaixaRepository>();
builder.Services.AddScoped<GeneroRepository>();
builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<PlayListMusicaRepository>();
builder.Services.AddScoped<TransacaoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<MusicaPlayListRepository>();

//Services
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<ArtistaService>();
builder.Services.AddScoped<CompositorService>();
builder.Services.AddScoped<FaixaService>();
builder.Services.AddScoped<GeneroService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<PlanoService>();
builder.Services.AddScoped<PlayListMusicaService>();
builder.Services.AddScoped<BandeiraService>();
builder.Services.AddScoped<CartaoService>();
builder.Services.AddScoped<TransacaoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<MusicaPlayListService>();

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();

    });
});


var app = builder.Build();

app.UseCors();

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
