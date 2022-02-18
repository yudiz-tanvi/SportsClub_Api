using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sportsclub_management.api.Filters;
using sportsclub_management.api.Helpers;
using sportsclub_management.models;
using sportsclub_management.models.Configs;
using sportsclub_management.repository;
using sportsclub_management.security;
using sportsclub_management.security.implementations;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sportsclub_management.api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }
		public static string CurrentLanguage { get; set; }

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

			#region Language translate

			services.AddLocalization(options => options.ResourcesPath = "Resources");

			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[] { new CultureInfo(LanguageConst.English), new CultureInfo(LanguageConst.Hindi) };
				options.DefaultRequestCulture = new RequestCulture(culture: LanguageConst.English, uiCulture: LanguageConst.English);
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
				options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
				{
					var userLangs = context.Request.Headers["Accept-Language"].ToString();
					var firstLang = userLangs.Split(',').FirstOrDefault();
					CurrentLanguage = (string.IsNullOrEmpty(firstLang) || (firstLang != LanguageConst.English && firstLang != LanguageConst.Hindi)) ? LanguageConst.English : firstLang;
					return Task.FromResult(new ProviderCultureResult(CurrentLanguage, CurrentLanguage));
				}));
			});

			#endregion Language translate

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

			var localizationOption = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
			app.UseRequestLocalization(localizationOption.Value);

			seed.Seed().Wait(); // Call Seed Method in Startup

			app.UseSwagger().UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/v1/swagger.json", "SportsClub APIs");
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
		#endregion Configure Method 
	}
}
