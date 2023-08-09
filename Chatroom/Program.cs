using Chatroom.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Chatroom.Plugins.EFCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Chatroom.Authentication;
using Chatroom.UseCases.PluginInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Plugins
builder.Services.AddTransient<IUserActions, UserActions>();

builder.Services.AddAuthentication(); // Auth
builder.Services.AddScoped<ProtectedSessionStorage>(); // Auth
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>(); // Auth

builder.Services.AddDbContext<ChatroomContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

var scope = app.Services.CreateScope();
var chatroomContext = scope.ServiceProvider.GetRequiredService<ChatroomContext>();
chatroomContext.Database.EnsureDeleted();
chatroomContext.Database.EnsureCreated();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
