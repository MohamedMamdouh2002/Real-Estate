
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyProject.Models.RealStates;
using MyProject.Services.AmenitiesServices;
using MyProject.Services.CompoundServices;
using MyProject.Services.DeveloperSerices;
using MyProject.Services.PaymentPlan;
using MyProject.Services.PaymentPlanServices;
using MyProject.Services.PhotoServices;
using MyProject.Services.ReaEStateTypeServices;
using MyProject.Services.RealEStatesServices;
using MyProject1.Models;
using MyProject1.Models.RealStates;
using MyProject1.Services;
using MyProject1.Services.AmenitiesCompoundServices;
using MyProject1.Services.CompoundImagesServices;
using MyProject1.Services.Filter;
using MyProject1.Services.ImageServices;
using MyProject1.Services.WishListServices;
using Project_1.Helper;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient<ICompoundServices, CompoundServices>();

builder.Services.AddTransient<IDeveloperServices, DeveloperServices>();

builder.Services.AddTransient<IRealEStateServices, RealEStateServices>();

builder.Services.AddTransient<IReaEStateTypeServices, ReaEStateTypeServices>();
builder.Services.AddTransient<IPaymentPlanServices, PaymentPlanServices>();
builder.Services.AddTransient<IFilterStrategyFactory, FilterStrategyFactory>();
builder.Services.AddTransient<IFilterServices, FilterServices>();


builder.Services.AddTransient<IImageServices<Developer>, DeveloperImageServices>();
builder.Services.AddTransient<IImageServices<Compound>, CompoundImageServices>();
builder.Services.AddTransient<IImageServices<Photo>, PhotoImageServices>();
builder.Services.AddTransient<IImageServices<Amenities>, AmenitiesImageServices>();
builder.Services.AddTransient<IImageServices<CompoundImages>, ImagesOfCompoundServices>();
builder.Services.AddTransient<IWishListServices, WIshListServices>();


builder.Services.AddTransient<IAmentiesServicces, AmenitiesServices>();
builder.Services.AddTransient<IAmenitiesCompoundServices, AmenitiesCompoundServices>();


builder.Services.AddTransient<IPhotoServices, PhotoServices>();
builder.Services.AddTransient<IPaymentPlanServices, PaymentPlanServices>();
builder.Services.AddTransient<ICompoundImageServices, CompoundImagesServices>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c=>c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();