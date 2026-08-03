using Microsoft.EntityFrameworkCore;
using SpiceFlow_Stock_Manager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SpiceFlowDataConnection")));
builder.Services.AddControllersWithViews(); /* Added for now so it would load page */
builder.Services.AddAuthorization(); /* Added for now so it would load page */

builder.Services.AddScoped<IOrderServices, OrderRepository>();
builder.Services.AddScoped<ISpiceServices, SpiceRepository>();
builder.Services.AddScoped<IUserServices, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
