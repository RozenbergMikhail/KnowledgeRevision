namespace X.Bits.Memory
{
    public class MemoryBitId : BitId
    {
        public MemoryBitId(int cellNumber)
        {
            CellNumber = cellNumber;
        }

        public int CellNumber { get; private set; }
    }
}
