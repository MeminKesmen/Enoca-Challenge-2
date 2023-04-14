

namespace Enoca.Application.Result
{
    public interface IDataResult<TData> : IResult
    {
        TData Data { get; set; }
    }
}
