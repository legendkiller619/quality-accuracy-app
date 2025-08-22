// File Structure for your Visual Studio Project
QualityAuditforecas/
|-- Properties/
|-- wwwroot/            <-- Create this folder
|   |-- index.html      <-- Drag and drop your index.html file here
|-- appsettings.json
|-- Program.cs
```csharp
// Program.cs
// This file is the entry point for your ASP.NET Core application.
// We are modifying it to serve static HTML files (like your index.html) instead of the default "Hello World" response.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This line is needed to enable serving static files.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see [https://aka.ms/aspnetcore-hsts](https://aka.ms/aspnetcore-hsts).
    app.UseHsts();
}

app.UseHttpsRedirection();
// This middleware enables the serving of static files from the wwwroot folder.
// This is the key change that allows your index.html to be displayed.
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
