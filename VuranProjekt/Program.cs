using DAL;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddRazorRuntimeCompilation();

builder.Services.AddDbContext <ReviewsAppDbContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("ReviewsAppDbContext"),
			opt => opt.MigrationsAssembly("DAL")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ReviewsAppDbContext>();

builder.Services.AddRazorPages();


builder.Services.AddControllersWithViews();




/*builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
		options.JsonSerializerOptions.WriteIndented = true;
	});
*/
/*builder.Services
	.AddAuthentication(options =>
	{
		options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
	})
	.AddCookie()
	.AddGoogleOpenIdConnect(options =>
	{
		options.ClientId = builder.Configuration["GOOGLE_CLIENT_ID"];
		options.ClientSecret = builder.Configuration["GOOGLE_CLIENT_SECRET"];
	});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

else
{
	/*{
    app.UseMigrationsEndPoint();
}*/
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

var supportedCultures = new[]
{
	new CultureInfo("hr"), new CultureInfo("en-US")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("hr"),
	SupportedCultures = supportedCultures,
	SupportedUICultures = supportedCultures
});

app.MapControllerRoute(
	name: "add-new",
	pattern: "add-new",
	defaults: new { controller = "Review", action = "Create" });


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
