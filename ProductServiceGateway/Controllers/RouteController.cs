using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductServiceGateway.Controllers
{
    [Authorize]
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
    }
}
