﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderServiceGateway.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {

    }
}
