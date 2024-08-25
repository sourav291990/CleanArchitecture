using CleanArchitecture.Presentation;
using CleanArchitecture.Web.Middlewares;
using CleanArchitecture.Web.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var corsSection = builder.Configuration.GetSection("CorsPolicyOptions");
var corsOptions = new CorsPolicyOptions();
corsSection.Bind(corsOptions);

builder.Services.Configure<CorsPolicyOptions>(corsSection);


//builder.Services.AddResponseCaching(options =>
//{
//    options.MaximumBodySize = 1024;
//    options.UseCaseSensitivePaths = true;
//});

// Register Presentation layer Services
builder.Services.RegisterPresentationServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsOptions.PolicyName, option =>
    {
        option.WithOrigins(corsOptions.AllowedOrigins)
              .WithMethods(corsOptions.AllowedMethods)
              .WithHeaders(corsOptions.AllowedHeaders);
    });
});

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
app.UseCors(corsOptions.PolicyName);
app.UseHttpsRedirection();
//app.UseResponseCaching();
//app.Use(async (context, next) =>
//{
//    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue
//    {
//        Public = true,
//        MaxAge = TimeSpan.FromSeconds(30)
//    };
//    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

//    await next(context);
//});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
