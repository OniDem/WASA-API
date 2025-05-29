using Asp.Versioning;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Services;
using StudentsManagementApi.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using WASA_InfrastructureLib.Repositories;

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

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ReceiptRepository>();
builder.Services.AddScoped<ShiftRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<SharedDataRepository>();
builder.Services.AddScoped<OrganizationRepository>();
builder.Services.AddScoped<CompatibleRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ReceiptService>();
builder.Services.AddScoped<ShiftService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<SharedDataService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<CompatibleService>();
Console.WriteLine(builder.Environment.EnvironmentName);

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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
