using CodeNotes.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<MarkdownFileReaderService>();
builder.Services.AddScoped<NavigationService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/errors/500");
}

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();