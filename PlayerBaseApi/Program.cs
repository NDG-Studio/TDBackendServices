using PlayerBaseApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SharedLibrary.Helpers;
using PlayerBaseApi.Helpers;
using PlayerBaseApi.Interfaces;
using PlayerBaseApi.Services;
using PlayerBaseApi.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});
builder.Services.AddDbContext<PlayerBaseContext>(o =>
{
    o.UseNpgsql(builder.Configuration["ConnectionStrings:PlayerBaseContext"]);
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

});

builder.Services.AddAutoMapper(
    typeof(PlayerBaseProfile),
    typeof(HeroProfile)
    );
builder.Services.AddScoped<IPlayerBaseService, PlayerBaseService>();
builder.Services.AddScoped<IHeroService, HeroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    using (var context = serviceScope.ServiceProvider.GetService<PlayerBaseContext>())
    {
        context.Database.Migrate();
    }
}
app.UseCors("ALLACCESSPOLICY");
app.UseMiddleware<ApiMiddleware>();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
