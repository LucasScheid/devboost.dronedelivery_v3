﻿using devboost.dronedelivery.felipe.EF;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class DbContextFactoryTests
    {
        [Fact]
        public void DbContextFactoryCreateTests()
        {
            var dbContextFactory = new DbContextFactory();
            var context = dbContextFactory.CreateDbContext(null);
            Assert.True(context != null);
        }
    }
}
