using Command.Message;
using Payroll.BL._Interfaces;
using Payroll.BL.Country;
using Payroll.BL.Department;
using Payroll.BL.Employee;
using Payroll.BL.Position;
using Payroll.BL.State;
using PayrollService.Utility;
using Serilog;
using Utility;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);



builder.Services.AddCors(p =>
    p.AddDefaultPolicy(policy =>
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IStateBL, StateBL>();
builder.Services.AddScoped<ICountryBL, CountryBL>();
builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IPositionBL, PositionBL>();
builder.Services.AddScoped<Message>();
builder.Services.AddRequestHandlers();
builder.Services.AddQueryHandlers();

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
