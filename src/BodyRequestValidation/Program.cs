using BodyRequestValidation.Dtos.Person;
using BodyRequestValidation.Services;
using BodyRequestValidation.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPersonService, InMemoryPersonService>();

#region Validators

ValidatorOptions.Global.LanguageManager.Enabled = false;

builder.Services.AddTransient<IValidator<PersonCreateRequestDto>, PersonCreateValidator>();

#endregion

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
