using System;
using Xunit;

using X.Dotnet;
using X.Bits.Moq;

namespace X.Bits.xUnit
{
    public class BitAggregateTests
    {
        [Fact]
        public void Constructor_ValidInput_ReturnsBitAggregate()
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateMockBits(0, 0, 0, 0, 0, 0, 0, 0));
            Assert.NotNull(bitAggregate);
        }

        [Fact]
        public void Constructor_NullInput_ThrowsException()
        {
            Action action = () => { new BitAggregate(null); };
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Constructor_EmptyInput_ThrowsException()
        {
            Action action = () => { new BitAggregate(MockBitFactory.CreateMockBits()); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(3, 1)]
        [InlineData(8, 5, 4)]
        public void Constructor_NullBitInput_ThrowsException(int bitCount, params int[] nullPositions)
        {
            var bits = MockBitFactory.CreateNullMockBits(bitCount, nullPositions);
            Action action = () => { new BitAggregate(bits); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(4, 0, 1)]
        [InlineData(8, 5, 7)]
        public void Constructor_SameBitInput_ThrowsException(int bitCount, params int[] samePositions)
        {
            var bits = MockBitFactory.CreateSameMockBits(bitCount, samePositions);
            Action action = () => { new BitAggregate(bits); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 1, 0, 0, 0)]
        public void Read_InitializedObject_ReturnsExpectedValue(params int[] initValues)
        {
            var bits = MockBitFactory.CreateMockBits(initValues);
            var bitAggregate = new BitAggregate(bits);

            var bitValues = bitAggregate.Read();

            Assert.Equal(bitValues, initValues);
        }

        [Theory]
        [InlineData(0, 0, 0, 0, 1, 0, 0, 0)]
        [InlineData(1, 0, 1, 0, 0, 1, 0, 1)]
        [InlineData(1, 1, 1, 1, 1, 1, 1, 1)]
        public void Update_WithValidData_MakesExpectedChanges(params int[] updateValues)
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateEmptyMockBits(8));

            bitAggregate.Update(updateValues);

            var bitValues = bitAggregate.Read();
            Assert.Equal(bitValues, updateValues);
        }

        [Fact]
        public void Update_WithNullData_ThrowsException()
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateEmptyMockBits(8));
            Action action = () => { bitAggregate.Update(null); };
            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData()]
        [InlineData(1, 0, 1, 0, 0, 1, 0, 1, 1, 0)]
        [InlineData(1, 1, 1)]
        public void Update_WithInvalidData_ThrowsException(params int[] updateValues)
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateEmptyMockBits(8));
            Action action = () => { bitAggregate.Update(updateValues); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void Clear_ZeroesAllBits()
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateMockBits(0, 1, 0, 0, 1, 1, 0, 0));

            bitAggregate.Clear();

            var bitValues = bitAggregate.Read();
            Assert.Equal(bitValues, ListFactory.CreateList(0, 0, 0, 0, 0, 0, 0, 0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ShiftLeft_PerformsAsExpected(int highestBitValue)
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateMockBits(1, 0, 1, 0, 1, 0, 1, highestBitValue));

            int carryFlagValue = bitAggregate.ShiftLeft();

            var bitValues = bitAggregate.Read();
            Assert.Equal(bitValues, ListFactory.CreateList(0, 1, 0, 1, 0, 1, 0, 1));
            Assert.Equal(highestBitValue, carryFlagValue);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void ShiftRight_PerformsAsExpected(int lowestBitValue)
        {
            var bitAggregate = new BitAggregate(MockBitFactory.CreateMockBits(lowestBitValue, 0, 1, 0, 1, 0, 1, 0));

            int carryFlagValue = bitAggregate.ShiftRight();

            var bitValues = bitAggregate.Read();
            Assert.Equal(bitValues, ListFactory.CreateList(0, 1, 0, 1, 0, 1, 0, 0));
            Assert.Equal(lowestBitValue, carryFlagValue);
        }
    }
}
