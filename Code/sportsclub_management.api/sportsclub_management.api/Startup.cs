using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sportsclub_management.api.Filters;
using sportsclub_management.repository;

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

			#region Registering Dependency Injections.
            
            services.AddSingleton<ExceptionFilters, ExceptionFilters>();
            
            #endregion
		}

		#region Configure Method 
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		// CTRL + k,s

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

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
