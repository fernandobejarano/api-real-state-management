using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MillionAndUp.Bussines;
using MillionAndUp.Cross_Cutting.Auth;
using MillionAndUp.Models.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MillionAndUp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //IMapper mapper = new MapperConfiguration((Action<IMapperConfigurationExpression>)(mc => mc.AddProfile((Profile)new MappingProfile()))).CreateMapper();
            //services.AddSingleton<IMapper>(mapper);
            //services.AddDbContext<SqlLiteDbContext>((Action<DbContextOptionsBuilder>)(options => SqliteDbContextOptionsBuilderExtensions.UseSqlite(options, Configuration.GetConnectionString("Sqlite"), (Action<SqliteDbContextOptionsBuilder>)(b => ((RelationalDbContextOptionsBuilder<SqliteDbContextOptionsBuilder, SqliteOptionsExtension>)b).MigrationsAssembly("MillionAndUp.Api")))));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOwnerBLL, OwnerBLL>();
            services.AddScoped<IPropertyBLL, PropertyBLL>();
            services.AddControllers();
            services.AddSwaggerGen((Action<SwaggerGenOptions>)(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "MillionAndUp.Api",
                    Version = "v1"
                });
                Path.Combine(AppContext.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".xml");
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                SwaggerGenOptions swaggerGenOptions = c;
                OpenApiSecurityRequirement securityRequirement1 = new OpenApiSecurityRequirement();
                OpenApiSecurityRequirement securityRequirement2 = securityRequirement1;
                OpenApiSecurityScheme key1 = new OpenApiSecurityScheme();
                key1.Reference = new OpenApiReference()
                {
                    Type = new ReferenceType?(ReferenceType.SecurityScheme),
                    Id = "Bearer"
                };
                string[] strArray = new string[0];
                securityRequirement2.Add(key1, strArray);
                OpenApiSecurityRequirement securityRequirement3 = securityRequirement1;
                swaggerGenOptions.AddSecurityRequirement(securityRequirement3);

                byte[] key = Encoding.ASCII.GetBytes("8C136A86-13EF-469F-8B8C-CC6797323C9A");
                services.AddAuthentication((Action<AuthenticationOptions>)(x =>
                {
                    x.DefaultAuthenticateScheme = "Bearer";
                    x.DefaultChallengeScheme = "Bearer";
                })).AddJwtBearer((Action<JwtBearerOptions>)(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = (SecurityKey)new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                }));
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MillionAndUp.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
