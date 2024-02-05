using Challenge.API.Filters;
using Challenge.Application.Commands.CreateAssociate;
using Challenge.Core.Repositories;
using Challenge.Infrastructure.Persistence;
using Challenge.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("ChallengeAPI");
builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connection));
builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services.AddValidatorsFromAssemblyContaining<CreateAssociateCommand>()
.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblies(typeof(CreateAssociateCommand).Assembly); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAssociateRepository, AssociateRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
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
