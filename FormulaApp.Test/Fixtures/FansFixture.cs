using FormulaApp.API.Models;
using System;


namespace FormulaApp.Test.Fixtures
{
    public class FansFixture
    {
        public static List<Fan> GetFans() => new()
        {
            new Fan()
            {
                Id = 1,
                Name = "Test",
                Email = "test@email.com"
            },
            new Fan()
            {
                Id = 2,
                Name = "don",
                Email = "don.donne@email.com"
            },
        };
    }
    
}

