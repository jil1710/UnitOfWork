using Microsoft.EntityFrameworkCore;
using UnitOfWork.Data;
using UnitOfWork.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseErrorHandalingMiddleware();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}"
);

app.Run();