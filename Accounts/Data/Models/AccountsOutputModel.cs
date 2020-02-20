using MVC_example_app.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
	public class AccountsOutputModel
	{
		public AccountsOutputModel()
		{
			EndOfDayBalances = new List<EndOfDayBalance>();
		}
		//Assuming the total credita and total debits is the total sum of the amounts and not the individual amount of total credi transations etc
		public decimal TotalCredits { get; set; }
		public decimal TotalDebits { get; set; }
		public List<EndOfDayBalance> EndOfDayBalances { get; set; }
	}
	//Could have done this model with a dictionay<DateTime,Decimal> but the json would have been slightly different from the desired output
	public class EndOfDayBalance
	{
		public DateTime Date { get; set; }
		public Decimal Balance { get; set; }
	}
}
