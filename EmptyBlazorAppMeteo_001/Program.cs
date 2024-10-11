/*
 * leoanardo mengozzi 
 * 5i
 * 2024-04-24
 * 
 * Modificare la stringa di connessione DbLombardi per qunado prof fa la prova.
 */

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EmptyBlazorAppMeteo_001.Class;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:HomeMeteo");

#pragma warning disable CS8604 // Possibile argomento di riferimento Null.
builder.Services.AddScoped<DataBase>(sp => new DataBase(connectionString));
#pragma warning restore CS8604 // Possibile argomento di riferimento Null.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
