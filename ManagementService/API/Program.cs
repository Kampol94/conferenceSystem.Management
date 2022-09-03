using EventService.API;
using ManagementService.API;
using ManagementService.Application;
using ManagementService.Application.Contracts;
using ManagementService.Domain.Users;
using ManagementService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<IExecutionContextAccessor, ExecutionContextAccessor>();
builder.Services.AddTransient<IUserContext, UserContext>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
