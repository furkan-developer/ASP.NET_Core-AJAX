using AJAX.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(new List<CommentViewModel>()
{
    new CommentViewModel(){CustomerName="Furkan Aydın",Comment="Lorem ipsum dolor sit amet consectetur adipisicing elit. Nam molestias vitae omnis. Quidem corporis illum recusandae debitis harum architecto modi odit assumenda perferendis alias eveniet rerum neque, maiores provident ipsum?"},

    new CommentViewModel(){CustomerName="Ali Veli",Comment="Lorem ipsum dolor sit amet consectetur adipisicing elit. Nam molestias vitae omnis."},
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
