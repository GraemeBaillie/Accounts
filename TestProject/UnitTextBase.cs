using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_example_app.Data;
using MVC_example_app.Interfaces;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;
using WebApplication1.Services;
using Xunit;

namespace XUnitTestProject1
{
    public abstract class UnitTestBase : IClassFixture<DIFixture>
    {
        protected ServiceProvider _serviceProvider;

        public UnitTestBase(DIFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }
    }
}
