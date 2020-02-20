using MVC_example_app.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
    public class TransactionModel
	{
		public string Description { get; set; }
		public decimal Amount { get; set; }
		public CreditDebitIndicatorEnum CreditDebitIndicator { get; set; }
		public TransationStatusEnum Status { get; set; }
		public DateTime BookingDate { get; set; }
	}
}
