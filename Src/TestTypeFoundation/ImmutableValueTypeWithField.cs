namespace TestTypeFoundation
{
    public struct ImmutableValueTypeWithField
    {
        public readonly object Field;

        public ImmutableValueTypeWithField(object field)
        {
            this.Field = field;
        }
    }
}