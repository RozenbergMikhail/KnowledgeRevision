using System;

namespace X.Bits.xUnit
{
    internal class TestBit : Bit
    {
        public TestBit(int bitStateCount) : base(bitStateCount)
        {
        }

        public override int GetValue()
        {
            throw new NotImplementedException();
        }

        protected override void SetValueInternal(int value)
        {
        }
    }
}
