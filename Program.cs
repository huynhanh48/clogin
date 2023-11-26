using System.Data.Common;
using Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using Login.Mail;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
var getEmail = builder.Configuration.GetConnectionString("MailSettings");
builder.Services.ConfigureAll<MailSettings>(options =>
{
    options.Mail = "anhvo482004@gmail.com";
    options.DisplayName = "anhvo482004";
    options.Password = "Anh0868299464";
    options.Host = "smtp.gmail.com";
    options.Port = 587;
});

builder.Services.AddSingleton<IEmailSender,SendMailService>();

// Add services to the container.
builder.Services.AddRazorPages();
var connections = builder.Configuration.GetConnectionString("Login");
    //builder.Services.Configure<MailSetting>(EMailSetting);
    builder.Services.AddDbContext<LoginContext>(options=> 
options.UseSqlServer(connections)
);

builder.Services.AddIdentity<Appuser,IdentityRole>()
.AddEntityFrameworkStores<LoginContext>()   
.AddDefaultTokenProviders();


// builder.Services.AddDefaultIdentity<Appuser>()
// .AddEntityFrameworkStores<LoginContext>()
// .AddDefaultTokenProviders();

// Truy cập IdentityOptions
    builder.Services.Configure<IdentityOptions> (options => {
    // Thiết lập về Password    
     options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại

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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
//dotnet aspnet-codegenerator razorpage -m Login.Model.Crud -dc Login.LoginContext --referenceScriptLibraries -udl --outDir Pages/Blog

