using System.Linq;
using System.Collections.Generic;
using System;

namespace X.Bits
{
    public class BitAggregate
    {
        private readonly IList<Bit> _bits;

        public BitAggregate(IList<Bit> bits)
        {
            if (bits == null)
                throw new ArgumentNullException(nameof(bits));

            if (bits.Count == 0)
                throw new ArgumentOutOfRangeException(nameof(bits), "The list of bits can't be empty");

            if (bits.Any(bit => bit == null))
                throw new ArgumentOutOfRangeException(nameof(bits), "Can't have NULLs within the list of bits");

            for (int i = 0; i < bits.Count - 1; i++)
            {
                for (int j = i + 1; j < bits.Count; j++)
                {
                    if (ReferenceEquals(bits[i], bits[j]))
                        throw new ArgumentOutOfRangeException(nameof(bits), "Same bit can't be added twice");
                }
            }

            _bits = bits;
        }

        public IList<int> Read()
        {
            return _bits.Select(x => x.GetValue()).ToList();
        }

        public void Update(IList<int> values)
        {
            if (values == null)
                throw new ArgumentNullException();

            if (values.Count != _bits.Count)
                throw new ArgumentOutOfRangeException(nameof(values));

            int i = 0;
            foreach (byte value in values)
            {
                _bits[i++].SetValue(value);
            }
        }

        public void Clear()
        {
            foreach (var bit in _bits)
            {
                bit.SetValue(Bit.MinBitValue);
            }
        }

        public int ShiftLeft()
        {
            int result = _bits[_bits.Count - 1].GetValue();

            for (int i = _bits.Count - 1; i > 0; i--)
            {
                _bits[i].SetValue(_bits[i - 1].GetValue());
            }

            _bits[0].SetValue(0);

            return result;
        }

        public int ShiftRight()
        {
            int result = _bits[0].GetValue();

            for (int i = 1; i < _bits.Count; i++)
            {
                _bits[i - 1].SetValue(_bits[i].GetValue());
            }

            _bits[_bits.Count - 1].SetValue(0);

            return result;
        }
    }
}
