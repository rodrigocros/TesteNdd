using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using TesteNdd.application.Commands.User;
using TesteNdd.application.Queries.GetAllUsers;
using TesteNdd.application.Validators;
using TesteNdd.infrastructure.Persistence;
using TesteNDD.domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMediatR(cfg => {
//    cfg.RegisterServicesFromAssemblyContaining<GetAllUsersQuery>();
//});

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(GetAllUsersQuery).Assembly);
});

var connectionString = builder.Configuration.GetConnectionString("TesteNdd");
builder.Services.AddDbContext<TesteNddContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
