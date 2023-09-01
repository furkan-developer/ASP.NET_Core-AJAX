using AJAX.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(new List<StudentModel>()
{
    new StudentModel(){ Id = 1,Email = "ankush1802@outlook.com",Name = "Ankush"},
    new StudentModel(){Id = 2,Email = "rohit@outlook.com",Name = "Rohit"},
    new StudentModel(){ Id = 3,Email = "sunny@outlook.com",Name = "Sunny"},
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
