using System;
using System.Collections.Generic;

using Moq;

namespace X.Bits.Moq
{
    public static class MockBitFactory
    {
        public static Bit CreateMockBit(int bitStateCount, int initialValue = Bit.MinBitValue)
        {
            int temp = initialValue;
            var mockBit = new Mock<Bit>(bitStateCount);
            mockBit.Setup(x => x.GetValue()).Returns(() => temp);
            mockBit.Setup(x => x.SetValue(It.IsAny<int>())).Callback<int>((value) => temp = value);
            return mockBit.Object;
        }

        public static IList<Bit> CreateMockBits(params int[] initialValues)
        {
            return CreateMockBitsInternal(initialValues.Length, (i) => CreateMockBit(Bit.MinBitStateCount, initialValues[i]));
        }

        public static IList<Bit> CreateEmptyMockBits(int count)
        {
            return CreateMockBitsInternal(count, (i) => CreateMockBit(Bit.MinBitStateCount));
        }

        public static IList<Bit> CreateNullMockBits(int count, IList<int> nullPositions)
        {
            return CreateInvalidMockBits(Bit.MinBitStateCount, count, nullPositions, null);
        }

        public static IList<Bit> CreateSameMockBits(int count, IList<int> samePositions)
        {
            return CreateInvalidMockBits(Bit.MinBitStateCount, count, samePositions, CreateMockBit(Bit.MinBitStateCount));
        }

        private static IList<Bit> CreateInvalidMockBits(int bitStateCount, int count, IList<int> invalidPositions, Bit invalidBit)
        {
            var positionsLookup = new HashSet<int>(invalidPositions);
            return CreateMockBitsInternal(count, (i) => positionsLookup.Contains(i) ? invalidBit : CreateMockBit(bitStateCount));
        }

        private static IList<Bit> CreateMockBitsInternal(int count, Func<int, Bit> createFunc)
        {
            var result = new List<Bit>();

            for (int i = 0; i < count; i++)
            {
                var bit = createFunc(i);
                result.Add(bit);
            }

            return result;
        }
    }
}
