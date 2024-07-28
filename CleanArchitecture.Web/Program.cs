using CleanArchitecture.Presentation;
using CleanArchitecture.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Register Presentation layer Services
builder.Services.RegisterPresentationServices(builder.Configuration);

// Add controllers specified in presentation layers
var presentationAssembly = typeof(PresentationAssemblyReference).Assembly;
builder.Services.AddControllers().AddApplicationPart(presentationAssembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
