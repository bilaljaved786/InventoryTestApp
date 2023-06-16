using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Inventory.Application.ManageInventory.Commands.CreateInventory;
using Inventory.WebApi.Extensions;
namespace Inventory.WebApi
{
	public class Startup
	{

		#region ctor

		private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		#endregion

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddMediatR(typeof(SellInventoryCommand));
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddSwagger();
			services.RegisterRepositories();
			services.AddDbContextCustomized(_configuration);
		}

		public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			#region Swagger

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json","My API V1");
				c.RoutePrefix = string.Empty;
			});

			#endregion
		}
	}
}
