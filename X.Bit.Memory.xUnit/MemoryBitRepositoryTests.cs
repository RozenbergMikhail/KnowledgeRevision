using System;
using Xunit;

namespace X.Bits.Memory.xUnit
{
    public class MemoryBitRepositoryTests
    {
        private const int StatesCount = 2;
        private const int MemoryCellCount = 100;

        private readonly MemoryBitRepository _memoryBitRepository;

        public MemoryBitRepositoryTests()
        {
            _memoryBitRepository = new MemoryBitRepository(StatesCount, MemoryCellCount);
        }

        [Fact]
        public void GetBit_NullBitId_ThrowsException()
        {
            Action action = () => { _memoryBitRepository.GetBit(null); };
            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(MemoryCellCount - 1)]
        public void GetBit_ValidBitId_ReturnsBit(int cellNumber)
        {
            var bit = _memoryBitRepository.GetBit(new MemoryBitId(cellNumber));
            Assert.NotNull(bit);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(MemoryCellCount)]
        public void GetBit_InvalidBitId_ThrowsException(int cellNumber)
        {
            Action action = () => { _memoryBitRepository.GetBit(new MemoryBitId(cellNumber)); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}
