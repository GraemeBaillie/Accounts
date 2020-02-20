using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_example_app.Data;
using MVC_example_app.Interfaces;
using NetCore.AutoRegisterDi;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using WebApplication1.Services;
using Xunit;

namespace XUnitTestProject1
{
    public class AccountsTest : UnitTestBase
    {
        public AccountsTest(DIFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void OutputTest()
        {
            var Account = JsonConvert.DeserializeObject<AccountRequestModel>(File.ReadAllText("./AppData/Account.json"));
            var outputs = _serviceProvider.GetService<IAccountService>().GetEndOfDayBalances(Account);
            //Tests in place to ensure the high level output numbers are correct
            Assert.Single(outputs);
            Assert.Equal(5, outputs[0].TotalCredits);
            Assert.Equal(10, outputs[0].TotalDebits);
            Assert.Equal(6, outputs[0].EndOfDayBalances.Count);

        }
    }
}
