using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UniversityLibrary.Data;
using UniversityLibrary.Helper;
using UniversityLibrary.Interfaces;
using UniversityLibrary.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
/*
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfiles());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
*/

builder.Services.AddAutoMapper(typeof(MappingProfiles));



builder.Services.AddDbContext<DataContext>(options =>{
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
