using System;
using Microsoft.Extensions.OptionsModel;
using Toolbox.DataAccess.Context;
using Toolbox.DataAccess.Options;

namespace Toolbox.DataAccess.UnitTests
{
    public class TestEntityContext : EntityContextBase
    {
        public TestEntityContext(IOptions<EntityContextOptions> options) : base(options)
        { }
    }
}
