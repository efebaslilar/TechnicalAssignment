using AutoMapper.Extensions.ExpressionMapping;
using BusinessLayer.Abstracts;
using BusinessLayer.Implamentations;
using DataAccessLayer.Abstracts;
using DataAccessLayer.ContextInfo;
using DataAccessLayer.Implamentations;
using EntityLayer.IdentityModels;
using EntityLayer.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_@.";
}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();


//Mapleme ayarlarý
//builder.Services.AddAutoMapper(typeof(Maps));
builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping(); //expressionlarý maplemek içindir
    x.AddProfile(typeof(Maps));
});

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductFeatureRepo, ProductFeatureRepo>();
builder.Services.AddScoped<IProductFeatureService, ProductFeatureService>();

builder.Services.AddScoped<IProductFeatureInformationRepo, ProductFeatureInformationRepo>();
builder.Services.AddScoped<IProductFeatureInformationService, ProductFeatureInformationService>();

builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

builder.Services.AddScoped<IBrandRepo, BrandRepo>();
builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<ICommentService, CommentService>();




// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
