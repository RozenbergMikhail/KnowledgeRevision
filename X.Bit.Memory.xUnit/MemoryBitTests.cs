using Xunit;

namespace X.Bits.Memory.xUnit
{
    public class MemoryBitTests
    {
        [Theory]
        [InlineData(Bit.MinBitStateCount)]
        [InlineData(Bit.MinBitStateCount + 1)]
        public void GetValue_ForUninitializedObject_ReturnsZero(int bitStateCount)
        {
            var bit = new MemoryBit(bitStateCount);
            Assert.Equal(0, bit.GetValue());
        }

        [Theory]
        [InlineData(Bit.MinBitStateCount, 0)]
        [InlineData(Bit.MinBitStateCount, 1)]
        [InlineData(Bit.MinBitStateCount + 1, 2)]
        public void SetValue_Valid_ChangesBitValue(int bitStateCount, int value)
        {
            var bit = new MemoryBit(bitStateCount);
            bit.SetValue(value);
            Assert.Equal(value, bit.GetValue());
        }
    }
}
