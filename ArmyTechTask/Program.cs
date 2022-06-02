using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ArmyTechTask.repository.Data;
using ArmyTechTask.repository.Interfaces;
using ArmyTechTask.repository.Repositories;
using ArmyTechTask.Service.Branch;
using ArmyTechTask.Service.Cashier;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ArmyTechTaskContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(ICashierService), typeof(CashierService));
builder.Services.AddScoped(typeof(IBranchService), typeof(BranchService));
builder.Services.AddScoped(typeof(IInvoiceService), typeof(InvoiceService));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ArmyTechTaskContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Invoice}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();