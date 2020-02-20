using Microsoft.AspNetCore.Hosting;
using MVC_example_app.Data;
using MVC_example_app.Data.Models.Enums;
using MVC_example_app.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public class AccountService : IAccountService
    {
        public List<AccountsOutputModel> GetEndOfDayBalances(AccountRequestModel model)
        {
            //I know returning a list of the output models may seem odd but i couldnt tell from the json schema whether there could be many. Looked like you were expecting an array?
            List<AccountsOutputModel> outputModels = new List<AccountsOutputModel>();
            foreach (var account in model.Accounts)
            {
                AccountsOutputModel outputModel = new AccountsOutputModel();
                //Again wasnt sure from the language in the spec what total Credits was mean to be so i took it that it was the count rather than the sum
                outputModel.TotalCredits = account.Transactions.Count(x => x.CreditDebitIndicator == CreditDebitIndicatorEnum.Credit);
                outputModel.TotalDebits = account.Transactions.Count(x => x.CreditDebitIndicator == CreditDebitIndicatorEnum.Debit);
                decimal balance = account.CurrentStartingBalance;
                //This could all be done in one line on linq but i found it easier to read and maintain with a normal loop
                foreach (var transactionsByDate in account.Transactions.GroupBy(d => d.BookingDate).OrderBy(x => x.Key))
                {
                    balance += (transactionsByDate.Where(x => 
                        x.CreditDebitIndicator == CreditDebitIndicatorEnum.Credit)
                            .Sum(c => c.Amount) -
                        transactionsByDate.Where(x => x.CreditDebitIndicator == CreditDebitIndicatorEnum.Debit)
                            .Sum(c => c.Amount));
                    outputModel.EndOfDayBalances.Add(new EndOfDayBalance { Date = transactionsByDate.Key, Balance = balance });
                }
                outputModels.Add(outputModel);
            }
            return outputModels;
        }
    }
}
