var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Uygulamada Session kullanmak istediğimiz için, sessiojn ayarlarını program.cs dosyasında yapıyoruz
builder.Services.AddSession(option =>
{

    option.IdleTimeout = TimeSpan.FromSeconds(30); // session'ın süresini belirledik!!
    // session süresini belirledik!!
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// yukarıda session ayarlarını yaptık!, Uygulamada session kullanacağımızı sisteme tanımlıyoruz!!(İzin almak gibi!)
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
