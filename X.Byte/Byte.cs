using System;
using System.Collections.Generic;

using X.Bits;

namespace X.Bytes
{
    public class Byte: BitAggregate
    {
        public Byte(IList<Bit> bits) : base(bits)
        {
            if (bits.Count != ByteMetadata.LengthInBits)
                throw new ArgumentOutOfRangeException(nameof(bits), $"Byte should have exactly {ByteMetadata.LengthInBits} bits");
        }
    }
}
