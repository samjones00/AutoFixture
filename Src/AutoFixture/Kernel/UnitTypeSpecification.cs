using System;
using System.Linq;
using System.Reflection;

namespace AutoFixture.Kernel
{
    public class UnitTypeSpecification : IRequestSpecification
    {
        public bool IsSatisfiedBy(object request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return request is Type type
                   && IsValueType(type)
                   && HasNoPublicProperties(type)
                   && HasNoPublicFields(type);
        }

        private static bool IsValueType(Type type) =>
            type.GetTypeInfo().IsValueType;

        private static bool HasNoPublicProperties(Type type) =>
            !type.GetTypeInfo().GetProperties().Any();

        private static bool HasNoPublicFields(Type type) =>
            !type.GetTypeInfo().GetFields().Any();
    }
}
