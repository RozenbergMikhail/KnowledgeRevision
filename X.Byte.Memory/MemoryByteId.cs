namespace X.Bytes.Memory
{
    public class MemoryByteId : ByteId
    {
        public MemoryByteId(int byteNumber)
        {
            ByteNumber = byteNumber;
        }

        public int ByteNumber { get; private set; }
    }
}
