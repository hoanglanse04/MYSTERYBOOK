using Microsoft.EntityFrameworkCore;
using MisteryBook.Models;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình Logging
builder.Services.AddLogging(options =>
{
    options.AddConsole(); // Đảm bảo log sẽ được ghi vào console
    options.AddDebug();   // Đảm bảo log sẽ được ghi vào cửa sổ Debug trong Visual Studio
    options.AddEventSourceLogger(); // Nếu cần, ghi log vào EventLog (Windows)
});

// Thêm dịch vụ MVC vào dự án
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Cấu hình DbContext
builder.Services.AddDbContext<QuanLyCuaHangSachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Cấu hình các middleware cho ứng dụng
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Cấu hình Routing cho các Area
app.UseRouting();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" // Cấu hình Route cho Area
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" // Route mặc định cho controller và action
);

// Kiểm tra kết nối cơ sở dữ liệu sau khi xây dựng ứng dụng thông qua IServiceScope
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<QuanLyCuaHangSachContext>();
        if (context.Database.CanConnect())
        {
            app.Logger.LogInformation("Kết nối cơ sở dữ liệu thành công.");
        }
        else
        {
            app.Logger.LogError("Không thể kết nối đến cơ sở dữ liệu.");
        }
    }
}
catch (Exception ex)
{
    app.Logger.LogError("Lỗi khi kiểm tra kết nối cơ sở dữ liệu: " + ex.Message);
}

// Chạy ứng dụng
app.Run();
