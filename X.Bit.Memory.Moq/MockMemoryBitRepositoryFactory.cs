using System;
using Moq;

using X.Bits.Moq;

namespace X.Bits.Memory.Moq
{
    public static class MockMemoryBitRepositoryFactory
    {
        public static IBitRepository<MemoryBitId> CreateMemoryBitRepository(int memoryCellCount, int bitStateCount = Bit.MinBitStateCount)
        {
            var memoryBitRepository = new Mock<IBitRepository<MemoryBitId>>();
            memoryBitRepository.Setup(x => x.GetBit(It.IsAny<MemoryBitId>())).Returns<MemoryBitId>(bitId =>
            {
                return (0 <= bitId.CellNumber && bitId.CellNumber < memoryCellCount) ? MockBitFactory.CreateMockBit(bitStateCount) : throw new ArgumentOutOfRangeException();
            });

            return memoryBitRepository.Object;
        }
    }
}
