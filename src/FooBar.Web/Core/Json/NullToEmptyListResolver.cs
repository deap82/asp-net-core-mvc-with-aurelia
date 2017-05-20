using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace FooBar.Web.Core.Json
{
    //Inspired from http://stackoverflow.com/a/25150302/226589
    public class NullToEmptyListResolver : CamelCaseExceptDictionaryKeysResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            IValueProvider provider = base.CreateMemberValueProvider(member);

            if (member.MemberType == MemberTypes.Property)
            {
                Type propType = ((PropertyInfo)member).PropertyType;
                TypeInfo propTypeInfo = propType.GetTypeInfo();
                if (propTypeInfo.IsGenericType &&
                    propType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    return new EmptyListValueProvider(provider, propType);
                }
            }

            return provider;
        }

        class EmptyListValueProvider : IValueProvider
        {
            private IValueProvider innerProvider;
            private object defaultValue;

            public EmptyListValueProvider(IValueProvider innerProvider, Type listType)
            {
                this.innerProvider = innerProvider;
                defaultValue = Activator.CreateInstance(listType);
            }

            public void SetValue(object target, object value)
            {
                innerProvider.SetValue(target, value ?? defaultValue);
            }

            public object GetValue(object target)
            {
                return innerProvider.GetValue(target) ?? defaultValue;
            }
        }
    }
}