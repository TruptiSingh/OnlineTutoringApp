using System.Globalization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using OTP.Api.Ioc;
using OTP.Repositories;

namespace OTP.Api
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
			services.AddControllers();

			var portalSite = Configuration ["PortalSite"];

			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder =>
					{
						builder
							.AllowAnyMethod()
							.AllowAnyHeader()
							.AllowCredentials()
							.WithOrigins(portalSite);
					});
			});

			var identityServerSite = Configuration ["IdentityServerSite"];

			var connectionString = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<OTPDbContext>(opt => opt
				.UseSqlServer(connectionString));

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.Authority = identityServerSite;
				o.Audience = "otpportalapi";
				o.RequireHttpsMetadata = false;
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "OTP Portal API",
					Description = "OTP Portal API",
				});
			});

			services.AddAuthorization();

			services.AddLocalization(options => options.ResourcesPath = "Resources");

			services.Configure<IConfiguration>(Configuration);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.Initialise();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			var supportedCultures = new []
			{
				new CultureInfo("en-GB")
			};

			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("en-GB"),
				SupportedCultures = supportedCultures,
				SupportedUICultures = supportedCultures
			});

			app.UseCors("AllowSpecificOrigin");

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "OTP Portal API V1");
			});
		}
	}
}
