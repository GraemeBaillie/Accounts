using MVC_example_app.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_example_app.Interfaces
{
    public interface IAccountService
    {
        List<AccountsOutputModel> GetEndOfDayBalances(AccountRequestModel model);
    }
}
