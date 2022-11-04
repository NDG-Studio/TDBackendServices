using Microsoft.EntityFrameworkCore;
using SharedLibrary.Helpers;
using WebSocket.Socket;
using WebSocket;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebSocket.Helpers;
using WebSocket.MapperProfiles;
using System.Configuration;
using WebSocket.Interfaces;
using PlayerBaseApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();

builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});

builder.Services.AddDbContext<WebSocketContext>(o =>
{
    o.UseNpgsql(builder.Configuration["ConnectionStrings:WebSocketContext"]);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "ALLACCESSPOLICY",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

builder.Services.AddAutoMapper(
    typeof(WebSocketProfile)
    );

builder.Services.AddScoped<INewsService, NewsService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

using (var serviceScope = app.Services
    .GetRequiredService<IServiceScopeFactory>()
    .CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<WebSocketContext>())
    {
        context.Database.Migrate();
    }
}

ServerProgram.Start();

app.UseCors("ALLACCESSPOLICY");
app.UseMiddleware<ApiMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
