using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using Super_Cartes_Infinies.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseLazyLoadingProxies();
});
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
SymmetricSecurityKey signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("C'est tellement la meilleure cle qui a jamais ete cree dans l'histoire de l'humanite (doit etre longue)"));
string serverAdress = "https://localhost:7179" +
    "";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    // TODO: Seulement lors du developement
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = true,
        ValidIssuer = serverAdress,
        ValidAudience = null,
        IssuerSigningKey = signingKey
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

// Injection de dépendance
builder.Services.AddScoped<PlayersService>();
builder.Services.AddScoped<CardsService>();
builder.Services.AddSingleton<WaitingUserService>();
builder.Services.AddScoped<MatchesService>();
builder.Services.AddScoped<StartingCardsService>();
builder.Services.AddScoped<MatchConfigurationService>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();


builder.Services.AddSignalR();

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
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapHub<MatchHub>("/matchHub");

app.Run();
