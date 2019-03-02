namespace X.Bytes
{
    public interface IByteRepository<TByteId>
        where TByteId : ByteId
    {
        Byte GetByte(TByteId byteId);
    }
}
