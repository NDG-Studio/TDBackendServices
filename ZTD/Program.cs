using ZTD;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ZTD.Helpers;
using ZTD.Interfaces;
using ZTD.Services;
using ZTD.MapperProfiles;
using SharedLibrary.Helpers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddDbLogger(options =>
{
    builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
});
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddDbContext<ZTDContext>(o =>
{
    o.UseNpgsql(builder.Configuration["ConnectionStrings:ZTDContext"]);
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
    typeof(UserProfile),
    typeof(TdProfile),
    typeof(DialogProfile)
    );
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ITdService, TdService>();
builder.Services.AddScoped<IDialogService, DialogService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services
    .GetRequiredService<IServiceScopeFactory>()
    .CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<ZTDContext>())
    {
        context.Database.Migrate();
    }
}
app.UseCors("ALLACCESSPOLICY");
app.UseMiddleware<JWTMiddleware>();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
