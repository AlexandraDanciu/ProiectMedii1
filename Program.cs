using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectMedii1.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options => 
{
    options.Conventions.AuthorizeFolder("/Members"); //acces doar daca ne autentificam
    options.Conventions.AuthorizeFolder("/Rentals");
    options.Conventions.AllowAnonymousToPage("/Equipments/Index"); //la toata lumea si nelogat
    options.Conventions.AllowAnonymousToPage("/Equipments/Details");
});
builder.Services.AddDbContext<ProiectMedii1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMedii1Context") ?? throw new InvalidOperationException("Connection string 'ProiectMedii1Context' not found.")));


builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMedii1Context") ?? throw new InvalidOperationException("Connectionstring 'ProiectMedii1Context' not found."))); 
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
