using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace devboost.dronedelivery.felipe.Security
{
    [ExcludeFromCodeCoverage]
    public class ValidateDatabse : IValidateDatabase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ValidateDatabse(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public bool EnsureCreated()
        {
            return _applicationDbContext.Database.EnsureCreated();
        }
    }
}
