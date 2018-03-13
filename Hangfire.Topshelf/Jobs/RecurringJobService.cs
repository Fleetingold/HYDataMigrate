using System;
using System.Collections.Generic;
using Hangfire.Console;
using Hangfire.RecurringJobExtensions;
using Hangfire.Server;
using Models;
using SqlSugar;
using Autofac;
using System.Linq;

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
        //[RecurringJob("*/1 * * * *")]
        //[System.ComponentModel.DisplayName("BaseDataMigrateJob")]
        //[Queue("jobs")]
        public void BaseDataMigrateJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} DataMigrateJob Running ...");

            var areaLists = SourceDB.Queryable<AreaList>().ToList();
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} DataMigrateJob 查询SourceDB.AreaList 个数为" + areaLists.Count.ToString());
            var deleteCount = TargetDB.Deleteable<AreaList>().ExecuteCommand();
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} DataMigrateJob 删除TargetDB.AreaList 个数为" + deleteCount);
            var insertConnt = TargetDB.Insertable(areaLists.ToArray()).ExecuteCommand();
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} DataMigrateJob 插入TargetDB.AreaList 个数为" + insertConnt);

            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }

        /// <summary>
        /// RecordDataMigrateJob 数据迁移job
        /// 周一至周五 9：00至18：00 整点触发
        /// </summary>
        /// <param name="context"></param>
        /// [RecurringJob("0 9-18 ? * MON-FRI")]
        [RecurringJob("0 9-18 * * *", "China Standard Time", "jobs")]
        [System.ComponentModel.DisplayName("RecordDataMigrateJob")]
        [Queue("jobs")]
        public void RecordDataMigrateJob(PerformContext context)
        {
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} RecordDataMigrateJob Running ...");

            // 从SourceDB查询出符合条件的FinaSettlementlist
            var finaSettlement10s = SourceDB.Queryable<Models.SourceDB.FinaSettlement>().Where(it => SqlFunc.Between(it.CreateDate, DateTime.Now.AddHours(-1), DateTime.Now)).ToList();
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} RecordDataMigrateJob 查询SourceDB.AreaList 个数为" + finaSettlement10s.Count.ToString());

            if (finaSettlement10s.Count == 0)
            {
                context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} 更新个数为" + finaSettlement10s.Count.ToString() + ",停止更新！");
            }
            else
            {
                var progressBar = context.WriteProgressBar();
                var insertConnt = 0;
                foreach (Models.SourceDB.FinaSettlement item in finaSettlement10s.WithProgress(progressBar))
                {
                    Models.TargetDB.FinaSettlement targetItem = new Models.TargetDB.FinaSettlement();
                    targetItem.ID = item.ID;
                    targetItem.SerialNumber = item.SerialNumber;
                    targetItem.ClerkID = item.ClerkID;
                    targetItem.ClerkNum = item.ClerkNum;
                    targetItem.Date = item.CreateDate;
                    targetItem.Company = item.Company;
                    targetItem.Reckoner = item.Reckoner;
                    targetItem.Money = item.Money;
                    targetItem.ClearingForm = item.ClearingForm;
                    targetItem.OpeningBank = item.OpeningBank;
                    targetItem.Account = item.Account;
                    targetItem.PrintCount = item.PrintCount;
                    targetItem.PaymentWay = item.PaymentWay;
                    targetItem.Verifier = item.Verifier;
                    targetItem.Status = item.Status;
                    targetItem.Creater = item.Creater;
                    targetItem.CreateDate = item.CreateDate;
                    targetItem.UpdateDate = item.UpdateDate;
                    targetItem.Remark = item.Remark;
                    targetItem.FundContent = "0.0";
                    // 为什么一个一个插入都不行？
                    int insert = TargetDB.Insertable(targetItem).ExecuteCommand();
                    insertConnt+=insert;
                }

                context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} RecordDataMigrateJob 插入TargetDB.AreaList 个数为" + insertConnt);
            }
            context.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} TrySqlSugarJob Running Over ...");
        }
    }
}
