using System;

namespace X.Bits
{
    public abstract class Bit
    {
        public const int MinBitStateCount = 2;
        public const int MinBitValue = 0;

        private readonly int _bitStateCount;

        public Bit(int bitStateCount)
        {
            if (bitStateCount < MinBitStateCount)
                throw new ArgumentOutOfRangeException(nameof(bitStateCount));

            _bitStateCount = bitStateCount;
        }

        public abstract int GetValue();

        public virtual void SetValue(int value)
        {
            if (value < MinBitValue || value >= _bitStateCount)
                throw new ArgumentOutOfRangeException(nameof(value));

            SetValueInternal(value);
        }

        protected abstract void SetValueInternal(int value);
    }
}
