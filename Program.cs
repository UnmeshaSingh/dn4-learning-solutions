using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI_WEEK_4.Filters;
using WebAPI_WEEK_4.Services; // ✅ Kafka service

namespace WebAPI_WEEK_4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Load JWT settings from appsettings.json
            var jwtKey = builder.Configuration["Jwt:Key"];
            var jwtIssuer = builder.Configuration["Jwt:Issuer"];
            var jwtAudience = builder.Configuration["Jwt:Audience"];

            // ✅ Configure JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            // ✅ Register filters, Kafka service, and controllers
            builder.Services.AddScoped<CustomExceptionFilter>();
            builder.Services.AddScoped<IKafkaProducerService, KafkaProducerService>(); // ✅ Kafka Producer DI

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>(); // Global error filter
            });

            // ✅ Swagger configuration with JWT support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger Demo",
                    Version = "v1",
                    Description = "WebAPI Hands-On - JWT Auth + Kafka Integration",
                    Contact = new OpenApiContact
                    {
                        Name = "John Doe",
                        Email = "john@example.com",
                        Url = new Uri("https://example.com/contact")
                    }
                });

                // 🔐 Add JWT bearer to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your JWT token"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            // ✅ Middleware pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // ✅ This will show the full error in response
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo v1");
                });
            }


            app.UseHttpsRedirection();

            app.UseAuthentication(); // 🔐 JWT Auth
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
