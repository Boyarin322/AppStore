namespace AppStore.Interfaces
{
    public interface IBaseResponse<T>
    {
        T Data { get; }
    }
}
