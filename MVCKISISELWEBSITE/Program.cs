using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(option=>
{
    option.Filters.Add(new LogFilter());//tüm action metodlara log filter tutulur.
});
//session ayarlamalarý
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromMinutes(20);//Session süresini belirtir    
    o.Cookie.IsEssential = true;
});

builder.Services.AddScoped<KisiselwebsiteContext>();// dependency injection uygulamasý Add Singelton uygulama boyunca bir kez çalýþýrsa hafýza az kullanýlýr.
builder.Services.AddScoped<LogFilter>();
builder.Services.AddScoped<LoginFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
