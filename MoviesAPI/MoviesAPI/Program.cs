using Microsoft.AspNetCore.Authentication.JwtBearer;
using MoviesAPI.Filters;
using MoviesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(MyExceptionFilter));
});
builder.Services.AddResponseCaching();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddSingleton<IRepository, InMemoryRepository>();
builder.Services.AddTransient<MyActionFilter>();
//AddTransient a new instance for every request
//AddSingleton 1 instance for all requests
//AddScoped one for each http request

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Short circuiting the pipeline");
//});

//app.Use(async (context, next) =>
//{
//    using (var swapStream = new MemoryStream())
//    {
//        var originalResponseBody = context.Response.Body;
//        context.Response.Body = swapStream;

//        await next.Invoke();

//        swapStream.Seek(0, SeekOrigin.Begin);
//        string responseBody = new StreamReader(swapStream).ReadToEnd();
//        swapStream.Seek(0, SeekOrigin.Begin);

//        await swapStream.CopyToAsync(originalResponseBody);
//        context.Response.Body = originalResponseBody;

//        var logger = new ILogger<Program>();
        
//        logger.LogInformation(responseBody);  
//    }
//});

//app.Map("/map1", (app) =>
//{
//    app.Run(async context =>
//    {
//        await context.Response.WriteAsync("Short circuiting the pipeline");
//    });
//}
//);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
