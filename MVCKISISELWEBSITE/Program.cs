using MVCKISISELWEBSITE.DAL;
using MVCKISISELWEBSITE.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(option=>
{
    option.Filters.Add(new LogFilter());//t�m action metodlara log filter tutulur.
});
//session ayarlamalar�
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromMinutes(20);//Session s�resini belirtir    
    o.Cookie.IsEssential = true;
});

builder.Services.AddScoped<KisiselwebsiteContext>();// dependency injection uygulamas� Add Singelton uygulama boyunca bir kez �al���rsa haf�za az kullan�l�r.
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
