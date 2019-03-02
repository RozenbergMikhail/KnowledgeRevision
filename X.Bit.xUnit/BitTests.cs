using System;
using Xunit;

namespace X.Bits.xUnit
{
    public class BitTests
    {
        [Theory]
        [InlineData(Bit.MinBitStateCount)]
        [InlineData(Bit.MinBitStateCount + 1)]
        public void Constructor_ValidStateCount_ReturnsBit(int bitStateCount)
        {
            var bit = new TestBit(bitStateCount);
            Assert.NotNull(bit);
        }

        [Theory]
        [InlineData(Bit.MinBitStateCount - 1)]
        public void Constructor_InvalidStateCount_ThrowsException(int bitStateCount)
        {
            Action action = () => { new TestBit(bitStateCount); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(Bit.MinBitStateCount, Bit.MinBitValue)]
        [InlineData(Bit.MinBitStateCount, Bit.MinBitValue + 1)]
        [InlineData(Bit.MinBitStateCount + 1, Bit.MinBitValue)]
        [InlineData(Bit.MinBitStateCount + 1, Bit.MinBitValue + 2)]
        public void SetValue_ValidValue_Succeeds(int bitStateCount, int value)
        {
            var bit = new TestBit(bitStateCount);
            bit.SetValue(value);
            Assert.True(true);
        }

        [Theory]
        [InlineData(Bit.MinBitStateCount, Bit.MinBitValue - 1)]
        [InlineData(Bit.MinBitStateCount, Bit.MinBitValue + 2)]
        [InlineData(Bit.MinBitStateCount + 1, Bit.MinBitValue + 3)]
        public void SetValue_InvalidValue_ThrowsException(int bitStateCount, int value)
        {
            var bit = new TestBit(bitStateCount);
            Action action = () => { bit.SetValue(value); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}
