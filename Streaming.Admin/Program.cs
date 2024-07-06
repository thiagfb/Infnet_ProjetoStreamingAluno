using Microsoft.EntityFrameworkCore;
using Streaming.Application.Admin;
using Streaming.Application.Admin.Profile;
using Streaming.Application.Conta;
using Streaming.Application.Streaming;
using Streaming.Application.Streaming.Profile;
using Streaming.Application.Transacao;
using Streaming.Repository;
using Streaming.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StreamingAdminContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("StreamingConnectionAdmin"));
});

builder.Services.AddDbContext<StreamingContext>(c =>
{
    c.UseLazyLoadingProxies()
     .UseSqlServer(builder.Configuration.GetConnectionString("StreamingConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioAdminProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ArtistaProfile).Assembly);

builder.Services.AddScoped<UsuarioAdminRepository>();
builder.Services.AddScoped<UsuarioAdminService>();

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
