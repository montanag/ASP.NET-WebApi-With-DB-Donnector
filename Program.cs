using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CSharpTourOfHeroes
{
	public class Program
	{

		public static void Main(string[] args)
		{
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = builder.Build();

			ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

			CreateWebHostBuilder(args).Build().Run();
		}

		public static IConfiguration Configuration { get; set; }

		public static String ConnectionString { get; private set; } 

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
