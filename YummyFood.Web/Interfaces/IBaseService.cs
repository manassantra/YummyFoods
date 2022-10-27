using YummyFood.Web.CommonBO;
using YummyFood.Web.Models;

namespace YummyFood.Web.Interfaces
{
    public interface IBaseService : IDisposable
    {
        ResponseMessegeBO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
