using SquareCalculatorSolution.Application.CalculatorService;
using SquareCalculatorSolution.Application.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICalculatorService, CalculatorService>();
builder.Services.AddTransient(typeof(SequenceDtoValidator)); 


var config = builder.Configuration;
builder.Services.AddOptions<SequenceOptions>()
    .Bind(config.GetSection(SequenceOptions.SectionName))
    .Validate(x =>
    {
        if (x.MinValue > x.MaxValue)
            return false;
        if (x.MaxNumber is < 0 or > int.MaxValue)
            return false;
        return true;
    })
    .ValidateDataAnnotations()
    .ValidateOnStart();

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
