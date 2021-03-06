using ApiSocialMedia.Extension;
using ApiSocialMedia.Extensions;
using Application;
using Persistence;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioningExtension();

#region Personal Dependency Injection
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddApllicationLayer();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseErrorHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
