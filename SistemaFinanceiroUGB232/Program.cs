var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Instituicao",
    pattern: "{controller=Instituicao}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Empresa",
    pattern: "Apoio/Empresa",
    defaults: new { controller = "Apoio", action = "Empresa" });

app.MapControllerRoute(
    name: "Empresa",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();