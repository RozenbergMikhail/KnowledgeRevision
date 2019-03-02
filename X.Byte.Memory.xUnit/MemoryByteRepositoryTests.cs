using System;
using Xunit;

using X.Bits.Memory.Moq;

namespace X.Bytes.Memory.xUnit
{
    public class MemoryByteRepositoryTests
    {
        private const int MemoryCellCount = 100;

        private readonly MemoryByteRepository _memoryByteRepository;

        public MemoryByteRepositoryTests()
        {
            var memoryBitRepository = MockMemoryBitRepositoryFactory.CreateMemoryBitRepository(MemoryCellCount);
            _memoryByteRepository = new MemoryByteRepository(memoryBitRepository);
        }

        [Fact]
        public void GetByte_NullByteId_ThrowsException()
        {
            Action action = () => { _memoryByteRepository.GetByte(null); };
            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(MemoryCellCount / ByteMetadata.LengthInBits - 1)]
        public void GetByte_ValidByteId_ReturnsByte(int byteNumber)
        {
            var b = _memoryByteRepository.GetByte(new MemoryByteId(byteNumber));
            Assert.NotNull(b);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(MemoryCellCount / ByteMetadata.LengthInBits)]
        public void GetByte_InvalidByteId_ThrowsException(int byteNumber)
        {
            Action action = () => { _memoryByteRepository.GetByte(new MemoryByteId(byteNumber)); };
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
    }
}
