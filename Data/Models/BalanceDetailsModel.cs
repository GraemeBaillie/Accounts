using MVC_example_app.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
    public class BalanceDetailsModel
    {
		//assuming amount will be an unformatted number i.e. no comma seperating
		public decimal Amount { get;set; }
		public CreditDebitIndicatorEnum CreditDebitIndicator { get;set; }
		public object CreditLines { get;set; }
    }
}
