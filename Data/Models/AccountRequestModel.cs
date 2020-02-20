using MVC_example_app.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
    public class AccountRequestModel
    {
        public string BrandName { get; set; }
        public string DataSourceName { get; set; }
        public DataSourceTypeEnum DataSourceType { get; set; }
        public DateTime RequestDateTime { get; set; }
	    //Assumption that there could be multiple accounts as its an array in the json
	    public List<AccountModel> Accounts{ get;set; }

    }
}
