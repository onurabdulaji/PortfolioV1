using PortfolioV1.Application.Extensions;
using PortfolioV1.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Persistence Layer Extensions
builder.Services.AddDatabaseExtension(builder.Configuration);
builder.Services.AddGenericPatternExtension();
builder.Services.AddUnitOfWorkExtension();
builder.Services.AddRepositoriesExtension();
#endregion

#region Application Layer Extensions
builder.Services.AddAppMapsterExtension();
builder.Services.AddMediatorExtension();
builder.Services.AddServicesExtension();
builder.Services.AddManagementsExtension();
builder.Services.AddFluentValidationExtension();
builder.Services.AddErrorHandlingServiceExtensions();
#endregion

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

app.UseAuthorization();

app.MapControllers();

app.Run();
