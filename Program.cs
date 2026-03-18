using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using airBnB.Data;
using airBnB;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<airBnBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("airBnBContext") ?? throw new InvalidOperationException("Connection string 'airBnBContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<airBnBContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options =>
    {
        options.Stores.MaxLengthForKeys = 128;
    })
.AddEntityFrameworkStores<airBnBContext>()
.AddRoles<IdentityRole>()
.AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Requires admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeFolder("/Booking", "Requires admin");
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())

{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<airBnBContext>(); context.Database.EnsureCreated();
        //DbInitializer.Initialize(context);
    }

    catch (Exception ex)
    {
        // Log details and fail fast or continue depending on your policy.
        logger.LogError(ex, "Database initialization failed. Check network, server, and credentials.");
throw;
    }
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.UseStaticFiles();


using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<airBnBContext>();
    context.Database.Migrate();
    var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentitySeedData.Initialize(context, userMgr, roleMgr).Wait();
}

    app.Run();
