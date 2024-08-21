using CleanArchitecture.Presentation;
using CleanArchitecture.Web.Middlewares;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
});

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
app.UseResponseCaching();
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(30)
    };
    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

    await next(context);
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
