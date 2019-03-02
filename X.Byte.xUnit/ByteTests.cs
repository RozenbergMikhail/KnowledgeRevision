using System;
using Xunit;

using X.Bits.Moq;

namespace X.Bytes.xUnit
{
    public class ByteTests
    {
        [Fact]
        public void Constructor_WithExpectedNumberOfBits_ReturnsByte()
        {
            var b = new Byte(MockBitFactory.CreateEmptyMockBits(ByteMetadata.LengthInBits));
            Assert.NotNull(b);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(ByteMetadata.LengthInBits - 1)]
        [InlineData(ByteMetadata.LengthInBits + 1)]
        public void Constructor_WithIncorrectNumberOfBits_ThrowsException(int bitCount)
        {
            Action action = () => { new Byte(MockBitFactory.CreateEmptyMockBits(bitCount)); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}
