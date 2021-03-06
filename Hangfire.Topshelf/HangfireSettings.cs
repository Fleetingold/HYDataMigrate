﻿using System;
using Microsoft.Extensions.Configuration;

namespace Hangfire.Topshelf
{
	public class HangfireSettings
	{
		private static readonly Lazy<HangfireSettings> _instance = new Lazy<HangfireSettings>(() => new HangfireSettings());

		public static HangfireSettings Instance => _instance.Value;

		public IConfigurationRoot Configuration { get; }

		private HangfireSettings()
		{
			var builder = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

			Configuration = builder.Build();
		}

		/// <summary>
		/// Windows ServiceName
		/// </summary>
		public string ServiceName => Configuration["hangfire.server.serviceName"];
		/// <summary>
		/// Windows ServiceDisplayName
		/// </summary>
		public string ServiceDisplayName => Configuration["hangfire.server.serviceDisplayName"];
		/// <summary>
		/// Windows ServiceDescription
		/// </summary>
		public string ServiceDescription => Configuration["hangfire.server.serviceDescription"];
		/// <summary>
		/// Windows ServiceAddress
		/// </summary>
		public string ServiceAddress => Configuration["hangfire.server.serviceAddress"];

		/// <summary>
		/// App WebSite
		/// </summary>
		public string AppWebSite => Configuration["hangfire.server.website"];

		/// <summary>
		/// hangfire login user
		/// </summary>
		public string LoginUser => Configuration["hangfire.login.user"];

		/// <summary>
		/// hangfire login pwd
		/// </summary>
		public string LoginPwd => Configuration["hangfire.login.pwd"];

		/// <summary>
		/// Hangfire sql server connectionstring
		/// </summary>
		public string HangfireSqlserverConnectionString => Configuration.GetConnectionString("hangfire.sqlserver");

		/// <summary>
		///  Hangfire redis server connectionstring
		/// </summary>
		public string HangfireRedisConnectionString => Configuration.GetConnectionString("hangfire.redis");

        /// <summary>
		///  SqlSugar sql server connectionstring
		/// </summary>
        public string SqlSugarSqlserverOilStationDBConnectionString => Configuration.GetConnectionString("sqlsugar.sqlserver.OilStationDB");

        /// <summary>
		///  SqlSugar oracle server connectionstring
		/// </summary>
        public string SqlSugarOracleConnectionString => Configuration.GetConnectionString("");

        #region 尝试没1分钟从HYERPBusiness10.AreaList复制数据到HYERPBusiness.AreaList
        /// <summary>
		///  SqlSugar sql server HYERPBusiness connectionstring
		/// </summary>
        public string SqlSugarSqlserverHYERPBusinessConnectionString => Configuration.GetConnectionString("sqlsugar.sqlserver.HYERPBusiness");

        /// <summary>
		///  SqlSugar sql server HYERPBusiness10 connectionstring
		/// </summary>
        public string SqlSugarSqlserverHYERPBusiness10ConnectionString => Configuration.GetConnectionString("sqlsugar.sqlserver.HYERPBusiness10");
        #endregion
    }
}
