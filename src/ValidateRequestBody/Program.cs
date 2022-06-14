using FluentValidation;
using FluentValidation.AspNetCore;
using ValidateRequestBody.Dtos.Person;
using ValidateRequestBody.Services;
using ValidateRequestBody.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IFoodService, FoodService>();

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

app.MapControllers();

app.Run();
