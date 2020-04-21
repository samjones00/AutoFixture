namespace TestTypeFoundation
{
    public struct MutableValueTypeWithField
    {
        public object Field;

        public MutableValueTypeWithField(object field)
        {
            this.Field = field;
        }
    }
}
