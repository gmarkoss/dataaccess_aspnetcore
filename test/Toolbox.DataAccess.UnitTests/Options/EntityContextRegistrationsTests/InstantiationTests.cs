using System;
using Toolbox.DataAccess.Options;
using Xunit;

namespace Toolbox.DataAccess.UnitTests.Options.EntityContextRegistrationsTests
{
    public class InstantiationTests
    {
        [Fact]
        private void RegistrationsIsInitialized()
        {
            var registrations = new EntityContextRegistrations();
            Assert.NotNull(registrations.Contexts);
        }
    }
}
