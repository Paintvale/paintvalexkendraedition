namespace Paintvale.Memory
{
    public interface IRefCounted
    {
        void IncrementReferenceCount();
        void DecrementReferenceCount();
    }
}
