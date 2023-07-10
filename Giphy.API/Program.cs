using Giphy.API;
using Giphy.API.Middleware;
using Giphy.API.Services;
using Giphy.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IGiphyGifService, GiphyGifService>();
builder.Services.AddScoped<IGiphyGifService, GiphyGifService>();
builder.Services.AddScoped<IWebApiCaller, WebApiCaller>();

builder.Services.AddCors(opt =>
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();  //.WithOrigins("https://localhost:4200")
            }));

SD.GiphyApiBase = builder.Configuration["ApiUrls:GiphyApi"];
//SD.ApiKey = builder.Configuration["ApiKey"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
