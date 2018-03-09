using System;
using System.Collections.Generic;
using System.ComponentModel;
using Hangfire.Console;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using Models;
using SqlSugar;

namespace Hangfire.Topshelf.Jobs
{
	public class RecurringJobService
	{
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
        [DisplayName("TrySqlSugarJob")]
        [Queue("jobs")]
        public void TrySqlSugarJob(PerformContext context,SqlSugarClient db)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running ...");
            List<Base_AreaList> list =  db.Queryable<Base_AreaList>().ToList();
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} GetBase_AreaList" + list.Count);
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }
	}
}
