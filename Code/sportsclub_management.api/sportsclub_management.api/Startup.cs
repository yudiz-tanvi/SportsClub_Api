using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using sportsclub_management.api.Filters;
using sportsclub_management.api.Helpers;
using sportsclub_management.models.Configs;
using sportsclub_management.repository;
using sportsclub_management.security;
using sportsclub_management.security.implementations;
using System;
using System.Text;

namespace sportsclub_management.api
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
			services.AddDbContext<SportsClubManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			//services.AddControllers();

			services.AddControllers()
			.ConfigureApiBehaviorOptions(options =>
			{
			  options.SuppressModelStateInvalidFilter = true;
			  options.SuppressConsumesConstraintForFormFileParameters = true;
			  options.SuppressInferBindingSourcesForParameters = true;
			  options.SuppressMapClientErrors = true;
			});

			#region JWT Authentication

			var key = Encoding.ASCII.GetBytes(Configuration["AuthConfigs:Key"]);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = false,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Configuration["AuthConfigs:Issuer"],
					ValidAudience = Configuration["AuthConfigs:Audiance"],
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ClockSkew = TimeSpan.Zero
				};
			});

			#endregion JWT Authentication

			#region Swagger Configuration

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "API Gateway",
					Version = "v1",
					Description = "Sportsclub API"
				});
			});

			#endregion Swagger Configuration

			#region Configs Initializations

			services.Configure<AuthConfigs>(Configuration.GetSection("AuthConfigs"));

			#endregion

			#region Registering Dependency Injections.

			services.AddSingleton<ICrypto, Crypto>();
			services.AddSingleton<ExceptionFilters, ExceptionFilters>();
			services.AddScoped<SeedHelpers>();

			#endregion
		}

		#region Configure Method 
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		// CTRL + k,s

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedHelpers seed)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			seed.Seed().Wait(); // Call Seed Method in Startup

			app.UseSwagger().UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/v1/swagger.json", "SportsClub APIs");
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
		#endregion Configure Method 
	}
}
