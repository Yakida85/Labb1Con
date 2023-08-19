using Labb1Con.Server.Data.Model;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PhonebookContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PhConnectionString"))
.UseCamelCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapGet("PhoneBook", (PhonebookContext context) =>
    {
       return context.PhonebooksTabel.ToList();
    }
);

app.MapPost("PhoneBook", (PhonebookContext context, PhoneBook phoneBook) =>
{
    context.PhonebooksTabel.Add(phoneBook);
    context.SaveChanges();
}
);

app.Run();
