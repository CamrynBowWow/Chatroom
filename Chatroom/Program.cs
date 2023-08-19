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
using Chatroom.UseCases.Interfaces;
using Chatroom.UseCases.ConversationActions;
using Chatroom.UseCases.MessageActions;
using Chatroom.Hubs;
using Microsoft.AspNetCore.ResponseCompression;
using Chatroom.UseCases.ContactActions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Plugins
builder.Services.AddTransient<IUserActions, UserActions>();
builder.Services.AddTransient<IConversationActions, ConversationActions>();
builder.Services.AddTransient<IMessageActions, MessageActions>();
builder.Services.AddTransient<IContactActions, ContactActions>();

// Use Cases
builder.Services.AddTransient<IFetchConversations, FetchConversations>();
builder.Services.AddTransient<IFetchMessages, FetchMessages>();
builder.Services.AddTransient<ISendMessage, SendMessage>();
builder.Services.AddTransient<IAddContact, AddContact>();
builder.Services.AddTransient<IFetchContacts, FetchContacts>();

builder.Services.AddCors();
builder.Services.AddSignalR();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

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

app.UseResponseCompression();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/userChat/{conId}");

});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();