using MVC_example_app.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_example_app.Data
{
    public class AccountModel
    {
	public int AccountID { get;set; }
        public CurrencyCode CurrencyCode { get;set; }
        public string DisplayName { get; set; }
        public AccountType AccountType{ get; set; }
        public AccountSubType AccountSubType { get; set; }
	    public IdentifierModel Identifiers{ get;set; }
	    //Created parties as an object as did not know the contents. Having a generic object or specific object allows for extension
	    public IList<PartyModel> Parties { get;set; }
	    //Created StandingOrders as an object as did not know the contents. Having a generic object or specific object allows for extension
	    public IList<StandingOrderModel> StandingOrders { get;set; }
	    //Created StandingOrders as an object as did not know the contents. Having a generic object or specific object allows for extension
	    public IList<DirectDebitModel> DirectDebits { get;set; }
        //Assuming there could be more types of balance other than current and available
        public Dictionary<BalanceType, BalanceDetailsModel> Balances { get; set; }
        public IList<TransactionModel> Transactions { get;set; }

        private decimal CreditCurrentStartingBalance { 
            get => Balances [BalanceType.current].CreditDebitIndicator == CreditDebitIndicatorEnum.Credit ?
                                        Balances [BalanceType.current].Amount :
                                            0;
        }
        private decimal DebitCurrentStartingBalance
        {
            get => Balances[BalanceType.current].CreditDebitIndicator == CreditDebitIndicatorEnum.Debit ?
                                        Balances[BalanceType.current].Amount :
                                        0;
        }

        public decimal CurrentStartingBalance
        {
            get => CreditCurrentStartingBalance - DebitCurrentStartingBalance;
        }
    }
}
