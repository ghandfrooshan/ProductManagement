using Framework.AssemblyHelper;
using Framework.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using ProductManagement.Persistence;
using System.Text.Json.Serialization;
//using Framework.ExceptionHandling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<ProductManagementDbContext>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
        options.LoginPath = "/Account/Login";
    });
var assemblyHelper = new AssemblyHelper(nameof(ProductManagement));
var mvcBuilder = builder.Services.AddMvc(option =>
{
    option.EnableEndpointRouting = false;
})
.AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

Registrar(builder.Services, assemblyHelper);

// Add services to the container.
builder.Services.AddControllersWithViews();

//AddControllers(assemblyHelper, mvcBuilder);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});
//builder.Services.AddAuthentication("Bearer")
//                .AddIdentityServerAuthentication(options =>
//                {
//                    options.Authority = builder.Configuration.GetSection("Identity:Authority").Value;
//                    options.RequireHttpsMetadata = bool.Parse(builder.Configuration.GetSection("Identity:RequireHttpsMetadata")?.Value ?? "false");
//                    options.ApiName = builder.Configuration.GetSection("Identity:ApiName").Value;
//                    options.SaveToken = bool.Parse(builder.Configuration.GetSection("Identity:SaveToken")?.Value ?? "false");
//                });
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IUserManager, UserManager>();
//builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddCors(o => o.AddPolicy("CrossDomainPolicy",
//                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    //app.ConfigureErrorHandlingMiddleware();
}



app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Account}/{action=Login}/{id?}");
    pattern: "{controller=Product}/{action=Index}/");
app.MapRazorPages();

app.Run();




void Registrar(IServiceCollection services, AssemblyHelper assemblyHelper)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
    foreach (IRegistrar registrar in registrars)
        registrar.Register(services, connectionString);


}











