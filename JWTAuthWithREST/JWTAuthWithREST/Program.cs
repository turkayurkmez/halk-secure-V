
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JWTAuthWithREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<UserService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(opt =>
                            {
                                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                                {
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidIssuer = "server",
                                    ValidAudience = "client",
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cümle-jwt-için-çok-gizli")),
                                    ValidateIssuerSigningKey = true
                                };
                            });

            builder.Services.AddCors(option => option.AddPolicy("allow", builder =>
            {
                /*
                 * http://www.halkbank.com.tr
                 * https://www.halkbank.com.tr
                 * https://credits.halkbank.com.tr
                 * https://credits.halkbank.com.tr:8088
                 * 
                 * http://www.halkbank.com.tr/basvuru
                 * 
                 */
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
            }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseCors("allow");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}