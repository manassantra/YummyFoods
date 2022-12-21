using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;
using YummyFood.Web.Models;

namespace YummyFood.Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClient;
        public AuthService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<T> Login<T>(LoginBO loginBo)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.POST,
                Data = loginBo,
                Url = ServiceDirectory.IdentityAPIBase + "/api/v1/JwtAuth/login",
            });
        }

        public async Task<T> Signup<T>(SignupBO signupBo)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ServiceDirectory.ApiType.POST,
                Data = signupBo,
                Url = ServiceDirectory.IdentityAPIBase + "/api/v1/JwtAuth/signup"
            });
        }

    }
}
