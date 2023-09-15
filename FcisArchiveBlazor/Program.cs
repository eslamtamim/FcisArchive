using FcisArchiveBlazor.Areas.Identity;
//using FcisArchiveBlazor.Data;
using FCISQuestionsHub.Core.Interfaces;
using FCISQuestionsHub.Core.Models;
using FCISQuestionsHub.EF.Data;
using FCISQuestionsHub.EF.Repos;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string DEFAULTCONNECTION = "DefaultConnection";
// string AZURESQL = "AzureSQL";

string psql = "psql";
var connectionString = builder.Configuration.GetConnectionString(psql) ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseNpgsql(connectionString));
builder.Services.AddTransient<ApplicationDbContext>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<StudentUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<StudentUser>>();
builder.Services.AddSingleton(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();