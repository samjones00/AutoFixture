namespace TestTypeFoundation
{
    public struct ImmutableValueTypeWithProperty
    {
        public ImmutableValueTypeWithProperty(object property)
        {
            this.Property = property;
        }

        public object Property { get; }
    }
}