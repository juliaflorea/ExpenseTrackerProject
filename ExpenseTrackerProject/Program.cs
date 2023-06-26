using Microsoft.EntityFrameworkCore;
using ExpenseTrackerProject.Models;
using ExpenseTrackerProject.Repositories.Interfaces;
using ExpenseTrackerProject.Repositories;
using ServiceStack.Logging;
using ExpenseTrackerProject.Services.Interfaces;
using ExpenseTrackerProject.Services;
using ExpenseTrackerProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Add(new ServiceDescriptor(typeof(IBudgetService), new BudgetService()));
builder.Services.Add(new ServiceDescriptor(typeof(ICategoryService), new CategoryService()));
builder.Services.Add(new ServiceDescriptor(typeof(IPaymentMethodService), new PaymentMethodService()));
builder.Services.Add(new ServiceDescriptor(typeof(IExpenseService), new ExpenseService()));
builder.Services.Add(new ServiceDescriptor(typeof(IIncomeService), new IncomeService()));
builder.Services.Add(new ServiceDescriptor(typeof(IUserService), new UserService()));

builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<IBudgetService, BudgetService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>();
builder.Services.AddScoped<IIncomeService, IncomeService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ExpenseTrackerDbConnection")));

//builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
//    .AddEntityFrameworkStores<ExpenseTrackerDbContext>()
//    .AddDefaultTokenProviders();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ExpenseTrackerDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "identity",
    pattern: "{area:exists}/{controller=home}/{action=Login}/{id?}");
app.MapControllerRoute(
    name: "identity",
    pattern: "{area:exists}/{controller=home}/{action=Register}/{id?}");



app.MapControllerRoute(
    name: "budget",
    pattern: "budget/{action=Index}/{id?}",
    defaults: new { controller = "Budget" });

app.MapControllerRoute(
    name: "expense",
    pattern: "Expense/{action=Index}/{id?}",
    defaults: new { controller = "Expense" });

app.MapControllerRoute(
    name: "income",
    pattern: "  Income/{action=Index}/{id?}",
    defaults: new { controller = "Income" });

app.MapControllerRoute(
    name: "expense",
    pattern: "PaymentMethod/{action=Index}/{id?}",
    defaults: new { controller = "PaymentMethod" });

app.MapControllerRoute(
    name: "category",
    pattern: "Category/{action=Index}/{id?}",
    defaults: new { controller = "Category" });

app.MapControllerRoute(
    name: "user",
    pattern: "User/{action=Index}/{id?}",
    defaults: new { controller = "User" });

app.MapRazorPages();
app.Run();
