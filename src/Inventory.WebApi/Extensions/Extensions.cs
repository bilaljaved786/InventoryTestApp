using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Inventory.Application.Interfaces.Persistence.Repositories;
using Inventory.Persistence;
using Inventory.Persistence.Data;
using Inventory.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventory.WebApi.Extensions
{
	public static class Extensions
	{
		public static void RegisterRepositories(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork,UnitOfWork>();
			services.AddScoped<IInventoryRepository,InventoryRepository>();
		}

		public static void AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				#region Swagger

				c.EnableAnnotations();
				c.SwaggerDoc("v1",new OpenApiInfo
				{
					Title = "Inventory App Web APIs",
					Version = "v1",
					Contact = new OpenApiContact
					{
						Name = "Bilal Javed",
						Email = "bilaljavedmughal@gmail.com"
					}
				});

				c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your token in the text input Example: Bearer ey11123231236546545",
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
				#endregion
			});
		}

		public static void AddDbContextCustomized(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
					.EnableSensitiveDataLogging()
					 .EnableDetailedErrors()
			);
		}
	}
}
