using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CSharpTourOfHeroes.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace CSharpTourOfHeroes
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// services.AddDbContext<HeroContext>(opt => opt.UseMySQL("server=localhost;user=root;database=events.potluck;port=3306;password=052995;SslMode=none"));
				// opt.UseInMemoryDatabase("HeroList"));
			services.AddCors(options => {
				options.AddPolicy("AllowAll", p => {
					p.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});
			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddDbContextPool<HeroContext>(
				options => options.UseMySql(Program.ConnectionString,
					mysqloptions =>
					{
						mysqloptions.ServerVersion(new System.Version(5,7,17), ServerType.MySql);
					}
				)
			);
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseCors("AllowAll");
			app.UseMvc();
		}
	}
}