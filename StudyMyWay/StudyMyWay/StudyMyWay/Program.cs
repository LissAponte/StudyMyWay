using StudyMyWay.Components;
using MongoDB.Bson;
using MongoDB.Driver;
using StudyMyWay.Components.Pages.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<BrowserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(StudyMyWay.Client._Imports).Assembly);

var dbClient = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
IMongoDatabase database = dbClient.GetDatabase("studymyway");

// Will focus on db use later on, just want to make sure it connects first
var collection = database.GetCollection<BsonDocument>("StudyRooms");

//var filter = Builders<BsonDocument>.Filter.Eq("Study_Room_Name","Math" );
//var doc = collection.Find(filter).FirstOrDefault();
//Console.WriteLine(doc.ToString());
app.Run();
