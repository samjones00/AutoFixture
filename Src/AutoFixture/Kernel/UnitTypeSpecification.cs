using System;
using System.Linq;

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
                   && type.IsValueType
                   && HasNoPublicProperties(type)
                   && HasNoPublicFields(type);
        }

        private static bool HasNoPublicProperties(Type type) =>
            !type.GetProperties().Any();

        private static bool HasNoPublicFields(Type type) =>
            !type.GetFields().Any();
    }
}
