using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Toolbox.DataAccess.Context;

namespace Toolbox.DataAccess.Options
{
    public class EntityContextRegistrations
    {
        private readonly Dictionary<string, Type> _contexts = new Dictionary<string, Type>();
        internal ReadOnlyDictionary<string, Type> Contexts
        {
            get { return new ReadOnlyDictionary<string, Type>(_contexts); }
        } 

        public EntityContextRegistrations Register(string key, Type entityContextType)
        {
            ValidateArguments(key, entityContextType);

            if ( _contexts.ContainsKey(key) ) throw new ArgumentException($"Registration with {nameof(key)} '{key}' already exists. Use a unique key per registration.", nameof(key));

            _contexts.Add(key, entityContextType);

            return this;
        }

        private void ValidateArguments(string key, Type entityContextType)
        {
            if ( key == null ) throw new ArgumentNullException(nameof(key), $"{nameof(key)} cannot be null.");
            if ( key.Trim() == String.Empty ) throw new ArgumentException($"{nameof(key)} must contain a valid string value.", nameof(key));
            if ( entityContextType == null ) throw new ArgumentNullException(nameof(entityContextType), $"{nameof(entityContextType)} cannot be null.");
            if ( !entityContextType.IsSubclassOf(typeof(EntityContextBase)) ) throw new ArgumentException($"{nameof(entityContextType)} does not inherit from EntityContextBase.", nameof(entityContextType));
        }
    }
}
