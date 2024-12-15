using CommonUtilities.API.Extensions;
using CommonUtilities.App.PipelineBehaviours.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.App.Queries;
using UserManagement.App.Repositories.Extensions;
using UserManagement.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();

builder.Services.AddDbContext<DbContext, UserManagementDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlDatabaseConnectionUserManagement"),
        new MySqlServerVersion(new Version(8, 0, 31)),
        b => b.MigrationsAssembly("UserManagement.API")
    ));

//Add mediatr
builder.Services.AddFluentValidationPipelineBehavior();
builder.Services.AddLoggingBehaviour();
builder.Services.AddTransactionAndDomainEventsBehavior();

builder.Services.AddValidatorsFromAssembly(typeof(HealthCheckQuery).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(HealthCheckQuery).Assembly));

var app = builder.Build();

app.UseCustomExceptionHandler();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<UserManagementDbContext>();
    dbContext.Database.Migrate();
}

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
