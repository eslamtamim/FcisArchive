using FcisArchiveBlazor.Areas.Identity;
using FcisArchiveBlazor.Services;
using FcisArchiveBlazor.Settings;
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
{
    //sending mails to users, using mailkit
    builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettingsGoogle"));
    builder.Services.AddTransient<IMaillingService, MaillingService>();
}
// cashing service
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

builder.Services.AddServerSideBlazor().AddCircuitOptions(options =>
{
    options.DetailedErrors = true;
});

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