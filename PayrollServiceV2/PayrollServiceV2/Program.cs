using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PayrollServiceV2.CommandRegistration;
using PayrollServiceV2.Extensions;
using Repository;
using Serilog;
using Service.BL;
using Swashbuckle.AspNetCore.SwaggerGen;
using Utility;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;
    setup.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});



//cerelog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


//CORS
builder.Services.AddCors(p =>
    p.AddDefaultPolicy(policy =>
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

//automapper
var mapperConfig = new MapperConfiguration(c =>
{
    c.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMemoryCache(p =>
{
    p.ExpirationScanFrequency = TimeSpan.FromMinutes(60);
});


builder.Services.AddControllers();

//EF
builder.Services.AddDbContext<PayrollContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConnection"],
            b => b.MigrationsAssembly(typeof(PayrollContext).Assembly.FullName));
});

builder.Services.AddScoped<PayrollContext>();
builder.Services.AddSingleton<DapperContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "V1", Version = "v1", Contact = new OpenApiContact { Name = "Aldo Salvani", Email = "aldo.salvani@gmail.com" } });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "V2", Version = "v2" });
});


builder.Services.AddDependencyInjection();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "Payroll Service - V1");
        options.SwaggerEndpoint("v2/swagger.json", "Payroll Service - V2");
    });
}

app.UseExceptionHandler("/error");

app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
