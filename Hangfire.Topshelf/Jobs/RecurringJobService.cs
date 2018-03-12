using System;
using System.Collections.Generic;
using Hangfire.Console;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using Models;
using SqlSugar;
using Autofac;

namespace Hangfire.Topshelf.Jobs
{
    /// <summary>
    /// RecurringJobService 循环任务服务
    /// DataMigrate的时候需要两个不同的SqlSugarClient连接
    /// 1）源数据库SqlSugarClient
    /// 2）目标数据库SqlSugarClient
    /// </summary>
    public class RecurringJobService
	{
        /// <summary>
        /// 源数据库SqlSugarClient
        /// </summary>
        public SqlSugarClient SourceDB { get; set; }
        /// <summary>
        /// 目标数据库SqlSugarClient
        /// </summary>
        public SqlSugarClient TargetDB { get; set; }

        //[RecurringJob("*/1 * * * *")]
        //[DisplayName("InstanceTestJob")]
        //[Queue("jobs")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void InstanceTestJob(PerformContext context)
		{
			context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} InstanceTestJob Running ...");
		}

		//[RecurringJob("*/5 * * * *")]
		//[DisplayName("JobStaticTest")]
		//[Queue("jobs")]
		/// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public static void StaticTestJob(PerformContext context)
		{
			context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} StaticTestJob Running ...");
		}

        //[RecurringJob("*/1 * * * *")]
        //[System.ComponentModel.DisplayName("TrySqlSugarJob")]
        //[Queue("jobs")]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void TrySqlSugarJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running ...");
            //string count = DB.Queryable<Base_AreaList>().Max(it => it.AreaCode);
            //context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} GetBase_AreaList " + count);
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }


        /// <summary>
        /// DataMigrateJob 数据迁移job
        /// </summary>
        /// <param name="context"></param>
        [RecurringJob("*/1 * * * *")]
        [System.ComponentModel.DisplayName("DataMigrateJob")]
        [Queue("jobs")]
        public void DataMigrateJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} DataMigrateJob Running ...");



            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }
	}
}
