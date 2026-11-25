using Microsoft.EntityFrameworkCore;
using Practical11.Data;
using Practical11.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CampusDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CampusDatabase")));

var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Requests}/{action=Index}/{id?}");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CampusDbContext>();
    db.Database.EnsureCreated();
}
app.Run();
