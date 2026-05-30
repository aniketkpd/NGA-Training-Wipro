using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


// Swagger + JWT Configuration

builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1",
new OpenApiInfo
{
    Title = "JWT Demo API",
    Version = "v1"
});


    // Add JWT Authentication to Swagger

    options.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter Bearer Token"
    });

    options.AddSecurityRequirement(
    new OpenApiSecurityRequirement
    {
    {
    new OpenApiSecurityScheme
    {
    Reference = new OpenApiReference
    {
    Type = ReferenceType.SecurityScheme,
    Id = "Bearer"
    }
    },
    new string[] {}
    }
    });
});




// JWT Authentication Setup

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
    JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,

    IssuerSigningKey =
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtKey"]))
};
});



builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// Enable Authentication Middleware

app.UseAuthentication();


// Enable Authorization Middleware

app.UseAuthorization();

app.MapControllers();

app.Run();
