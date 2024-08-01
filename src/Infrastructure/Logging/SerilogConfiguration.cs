﻿using Microsoft.Extensions.Hosting;
using Serilog;
using System.Reflection;
using Elastic.Serilog.Sinks;
using Elastic.Channels;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch;
using Microsoft.Extensions.Configuration;
namespace Logging
{
	public static class SerilogConfiguration
	{
		public static Action<HostBuilderContext, LoggerConfiguration> Configure => 
		(context, loggerConfiguration) =>
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			//const string template = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Indent:l} {Message}{NewLine}{Exception}";
			loggerConfiguration
				.WriteTo.Console() //outputTemplate: template
				.WriteTo.Debug()
				.WriteTo.File(path: @"Logs/log.txt", rollingInterval: RollingInterval.Day)
				.WriteTo.Elasticsearch(new[] { new Uri("http://localhost:9200") }, opts =>
				{
					opts.DataStream = new DataStreamName("logs", context.Configuration.GetValue("ServiceName", defaultValue:"unknown")!, "shelfshare");
					opts.BootstrapMethod = BootstrapMethod.Failure;
				})
				.Enrich.WithProperty("Application", context.HostingEnvironment.ApplicationName)
				.Enrich.WithProperty("ContentRootPath", context.HostingEnvironment.ContentRootPath)
				.Enrich.WithMachineName()
				.Enrich.WithEnvironmentName()
				.Enrich.FromLogContext()
				.ReadFrom.Configuration(context.Configuration);
		};
	}
}