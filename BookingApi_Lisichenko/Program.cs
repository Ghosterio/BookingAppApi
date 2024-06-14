using Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Repository;
using Repository.Additional_ServiceRepository;
using Repository.Booking_DetailsRepository;
using Repository.BookingRepository;
using Repository.JwtRepository;
using Repository.Main_ServiceRepository;
using Repository.PaymentRepository;
using Repository.StatusRepository;
using Repository.RoomRepository;
using Repository.UserRepository;
using Service.Additional_ServiceService;
using Service.Booking_DetailsService;
using Service.BookingService;
using Service.JwtService;
using Service.Main_ServiceService;
using Service.PaymentService;
using Service.StatusService;
using Service.RoomService;
using Service.UserService;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped(typeof(IAdditional_ServiceRepository), typeof(Additional_ServiceRepository));
builder.Services.AddTransient<IAdditional_ServiceService, Additional_ServiceService>();

builder.Services.AddScoped(typeof(IBooking_DetailsRepository), typeof(Booking_DetailsRepository));
builder.Services.AddTransient<IBooking_DetailsService, Booking_DetailsService>();

builder.Services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));
builder.Services.AddTransient<IBookingService, BookingService>();

builder.Services.AddScoped(typeof(IMain_ServiceRepository), typeof(Main_ServiceRepository));
builder.Services.AddTransient<IMain_ServiceService, Main_ServiceService>();

builder.Services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
builder.Services.AddTransient<IPaymentService, PaymentService>();

builder.Services.AddScoped(typeof(IStatusRepository), typeof(StatusRepository));
builder.Services.AddTransient<IStatusService, StatusService>();

builder.Services.AddScoped(typeof(IRoomRepository), typeof(RoomRepository));
builder.Services.AddTransient<IRoomService, RoomService>();

builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddScoped(typeof(IJwtRepository), typeof(JwtRepository));
builder.Services.AddTransient<IJwtService, JwtService>();

builder.Services.AddIdentityCore<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.UseSecurityTokenValidators = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = "bookapilan",
            ValidIssuer = "bookapilan",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("8b0fa5c39bcc9d22a9d4c8d42ba40fd73c85488b4c43d74b1b26122fe4301700"))
        };
    });

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();