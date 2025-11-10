using Asp.Versioning;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentsManagementApi.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(opt =>
{
    opt.OperationFilter<SwaggerDefaultValues>();

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
}).AddMvc().AddApiExplorer(
    options =>
    {

        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    }
);
//Don`t update package to preview versions & change connectionString (Environment.GetEnvironmentVariable("CONNECTION_STRING"))
builder.Services.AddDbContext<ApplicationContext>(options => { options.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_STRING"), b => b.MigrationsAssembly("WASA-API")); });

builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.UserRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.ProductRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.ReceiptRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.ShiftRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.CategoryRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.SharedDataRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.OrganizationRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v1.CompatibleRepository>();

builder.Services.AddScoped<Infrastructure.Repositories.v2.UserRepository>();
builder.Services.AddScoped<Infrastructure.Repositories.v2.ProductRepository>();
builder.Services.AddScoped<Infrastructure.Repositories.v2.ReceiptRepository>();
builder.Services.AddScoped<Infrastructure.Repositories.v2.ShiftRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v2.CategoryRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v2.SharedDataRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v2.OrganizationRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v2.CompatibleRepository>();
builder.Services.AddScoped<WASA_InfrastructureLib.Repositories.v2.RepairRepository>();

builder.Services.AddScoped<Services.v1.UserService>();
builder.Services.AddScoped<Services.ProductService>();
builder.Services.AddScoped<Services.v1.ReceiptService>();
builder.Services.AddScoped<Services.v1.ShiftService>();
builder.Services.AddScoped<Services.v1.CategoryService>();
builder.Services.AddScoped<Services.v1.SharedDataService>();
builder.Services.AddScoped<Services.v1.OrganizationService>();
builder.Services.AddScoped<Services.v1.CompatibleService>();

builder.Services.AddScoped<Services.v2.UserService>();
builder.Services.AddScoped<Services.v2.ProductService>();
builder.Services.AddScoped<Services.v2.ReceiptService>();
builder.Services.AddScoped<Services.v2.ShiftService>();
builder.Services.AddScoped<Services.v2.CategoryService>();
builder.Services.AddScoped<Services.v2.SharedDataService>();
builder.Services.AddScoped<Services.v2.OrganizationService>();
builder.Services.AddScoped<Services.v2.CompatibleService>();
builder.Services.AddScoped<Services.v2.RepairService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = false,
            RequireExpirationTime = false,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });




var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    // Build a swagger endpoint for each discovered API version
    foreach (var description in descriptions)
    {
        var url = $"/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();
        options.SwaggerEndpoint(url, name);
    }
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



app.Run();

public class AuthOptions
{
    public const string ISSUER = "WASA-API"; // издатель токена
    public const string AUDIENCE = "WASA-CRM"; // потребитель токена
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")));
}
