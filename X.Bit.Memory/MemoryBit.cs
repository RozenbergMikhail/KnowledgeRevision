namespace X.Bits.Memory
{
    public class MemoryBit : Bit
    {
        private int _value;

        public MemoryBit(int bitStateCount) : base(bitStateCount)
        {
        }

        public override int GetValue()
        {
            return _value;
        }

        protected override void SetValueInternal(int value)
        {
            _value = value;
        }
    }
}
