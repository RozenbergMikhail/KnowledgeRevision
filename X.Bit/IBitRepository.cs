namespace X.Bits
{
    public interface IBitRepository<TBitId>
        where TBitId : BitId
    {
        Bit GetBit(TBitId bitId);
    }
}
