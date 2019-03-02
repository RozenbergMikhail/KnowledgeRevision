using System;
using System.Collections.Generic;

namespace X.Bits.Memory
{
    public class MemoryBitRepository : IBitRepository<MemoryBitId>
    {
        private readonly IDictionary<int, Bit> _bits;

        public MemoryBitRepository(int bitStateCount, int cellCount)
        {
            _bits = AllocateMemoryBits(bitStateCount, cellCount);
        }

        public Bit GetBit(MemoryBitId bitId)
        {
            if (bitId == null)
                throw new ArgumentNullException(nameof(bitId));

            if (!_bits.TryGetValue(bitId.CellNumber, out var result))
                throw new ArgumentOutOfRangeException(nameof(bitId));

            return result;
        }

        private static Dictionary<int, Bit> AllocateMemoryBits(int bitStateCount, int cellCount)
        {
            var result = new Dictionary<int, Bit>();

            for (int i = 0; i < cellCount; i++)
            {
                result.Add(i, new MemoryBit(bitStateCount));
            }

            return result;
        }
    }
}
