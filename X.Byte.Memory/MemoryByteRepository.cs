using System;
using System.Collections.Generic;
using System.Linq;

using X.Bits;
using X.Bits.Memory;

namespace X.Bytes.Memory
{
    public class MemoryByteRepository : IByteRepository<MemoryByteId>
    {
        private readonly IBitRepository<MemoryBitId> _memoryBitRepository;

        public MemoryByteRepository(IBitRepository<MemoryBitId> memoryBitRepository)
        {
            _memoryBitRepository = memoryBitRepository;
        }

        public Byte GetByte(MemoryByteId byteId)
        {
            if (byteId == null)
                throw new ArgumentNullException(nameof(byteId));

            var memoryBitIds = GetBitIdsByByteId(byteId);
            var memoryBits = memoryBitIds.Select(bitId => _memoryBitRepository.GetBit(bitId)).ToList();
            return new Byte(memoryBits);
        }

        private IList<MemoryBitId> GetBitIdsByByteId(MemoryByteId byteId)
        {
            var result = new List<MemoryBitId>();

            int byteOffset = byteId.ByteNumber * ByteMetadata.LengthInBits;
            for (int i = byteOffset; i < byteOffset + ByteMetadata.LengthInBits; i++)
            {
                result.Add(new MemoryBitId(i));
            }

            return result;
        }
    }
}
