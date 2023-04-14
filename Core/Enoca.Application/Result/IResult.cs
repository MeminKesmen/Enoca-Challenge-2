
namespace Enoca.Application.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; set; }
    }
}
