using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Citizens.Tests
{
    public class TestsBase
    {
        protected readonly DateTime TestTodayDate = System.DateTime.Today;

        [TestInitialize]
        public virtual void Initialize()
        {
            SystemDateTime.Now = () => TestTodayDate;
        }
    }
}