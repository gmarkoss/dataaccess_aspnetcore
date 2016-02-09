using System;
using Toolbox.DataAccess.Options;
using Xunit;

namespace Toolbox.DataAccess.UnitTests.Options.EntityContextRegistrationsTests
{
    public class RegisterTests
    {
        [Fact]
        private void ReturnsObjectItSelf()
        {
            var registrations = new EntityContextRegistrations();
            var ret = registrations.Register("key", typeof(TestEntityContext));
            Assert.Same(registrations, ret);
        }

        [Fact]
        private void KeyNullRaisesArgumentNullException()
        {
            var registrations = new EntityContextRegistrations();
            var ex = Assert.Throws<ArgumentNullException>(() => registrations.Register(null, typeof(TestEntityContext)));
            Assert.Equal("key", ex.ParamName);
        }

        [Fact]
        private void KeyEmptyRaisesArgumentNullException()
        {
            var registrations = new EntityContextRegistrations();
            var ex = Assert.Throws<ArgumentException>(() => registrations.Register("", typeof(TestEntityContext)));
            Assert.Equal("key", ex.ParamName);
        }

        [Fact]
        private void KeyWhitespaceRaisesArgumentNullException()
        {
            var registrations = new EntityContextRegistrations();
            var ex = Assert.Throws<ArgumentException>(() => registrations.Register("     ", typeof(TestEntityContext)));
            Assert.Equal("key", ex.ParamName);
        }

        [Fact]
        private void EntityContextTypeNullRaisesArgumentNullException()
        {
            var registrations = new EntityContextRegistrations();
            var ex = Assert.Throws<ArgumentNullException>(() => registrations.Register("key", null));
            Assert.Equal("entityContextType", ex.ParamName);
        }

        [Fact]
        private void InvalidEntityContextTypeRaisesArgumentException()
        {
            var registrations = new EntityContextRegistrations();
            var ex = Assert.Throws<ArgumentException>(() => registrations.Register("key", this.GetType()));
            Assert.Equal("entityContextType", ex.ParamName);
        }

        [Fact]
        private void EntityContextTypeIsRegistered()
        {
            var registrations = new EntityContextRegistrations();
            registrations.Register("key", typeof(TestEntityContext));

            Assert.Equal(1, registrations.Contexts.Count);
            Assert.Equal(typeof(TestEntityContext), registrations.Contexts["key"]);
        }

        [Fact]
        private void SameKeyTwiceRaisesArgumentException()
        {
            var registrations = new EntityContextRegistrations();
            registrations.Register("key", typeof(TestEntityContext));

            var ex = Assert.Throws<ArgumentException>(() => registrations.Register("key", typeof(TestEntityContext)));
            Assert.Equal("key", ex.ParamName);
            Assert.Contains("already exists", ex.Message);
        }

        // ToDo (SVB) : default key is registered

        // ToDo (SVB) : default only once

        // ToDo (SVB) : same key as default only once

        // ToDo (SVB) : generics
    }
}
