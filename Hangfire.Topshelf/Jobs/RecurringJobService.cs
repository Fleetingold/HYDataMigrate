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
	public class RecurringJobService
	{
        public SqlSugarClient DB { get; set; }

        //[RecurringJob("*/1 * * * *")]
        //[DisplayName("InstanceTestJob")]
        //[Queue("jobs")]
        public void InstanceTestJob(PerformContext context)
		{
			context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} InstanceTestJob Running ...");
		}

		//[RecurringJob("*/5 * * * *")]
		//[DisplayName("JobStaticTest")]
		//[Queue("jobs")]
		public static void StaticTestJob(PerformContext context)
		{
			context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} StaticTestJob Running ...");
		}

        [RecurringJob("*/1 * * * *")]
        [System.ComponentModel.DisplayName("TrySqlSugarJob")]
        [Queue("jobs")]
        public void TrySqlSugarJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running ...");
            string count = DB.Queryable<Base_AreaList>().Max(it => it.AreaCode);
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} GetBase_AreaList " + count);
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }
	}
}
