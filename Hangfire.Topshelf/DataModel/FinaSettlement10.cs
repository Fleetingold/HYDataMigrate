using System;
using System.Linq;
using System.Text;

namespace Models.SourceDB
{
    ///<summary>
    ///结款单表
    ///</summary>
    public partial class FinaSettlement
    {
           public FinaSettlement(){


           }
           /// <summary>
           /// Desc:结款单ID(主键)
           /// Default:newid()
           /// Nullable:False
           /// </summary>           
           public Guid ID {get;set;}

           /// <summary>
           /// Desc:结款单号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SerialNumber {get;set;}

           /// <summary>
           /// Desc:业务员ID（外键）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public Guid? ClerkID {get;set;}

           /// <summary>
           /// Desc:业务员编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ClerkNum {get;set;}

           /// <summary>
           /// Desc:结款单位
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Company {get;set;}

           /// <summary>
           /// Desc:结算人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Reckoner {get;set;}

           /// <summary>
           /// Desc:结算金额
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal Money {get;set;}

           /// <summary>
           /// Desc:结算方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ClearingForm {get;set;}

           /// <summary>
           /// Desc:开户行
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OpeningBank {get;set;}

           /// <summary>
           /// Desc:账号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Account {get;set;}

           /// <summary>
           /// Desc:打印次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int PrintCount {get;set;}

           /// <summary>
           /// Desc:付款方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PaymentWay {get;set;}

           /// <summary>
           /// Desc:0是未审核1是已审核。(默认是0)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int State {get;set;}

           /// <summary>
           /// Desc:审核人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Verifier {get;set;}

           /// <summary>
           /// Desc:审核时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? VerifyDate {get;set;}

           /// <summary>
           /// Desc:该记录是活记录或死记录
           /// Default:0
           /// Nullable:True
           /// </summary>           
           public int? Status {get;set;}

           /// <summary>
           /// Desc:经办人
           /// Default:N'admin'
           /// Nullable:False
           /// </summary>           
           public string Creater {get;set;}

           /// <summary>
           /// Desc:结款日期
           /// Default:DateTime.Now
           /// Nullable:False
           /// </summary>           
           public DateTime CreateDate {get;set;}

           /// <summary>
           /// Desc:最后一次修改人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Updater {get;set;}

           /// <summary>
           /// Desc:最后一次修改时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UpdateDate {get;set;}

           /// <summary>
           /// Desc:款项内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Remark {get;set;}

    }
}
