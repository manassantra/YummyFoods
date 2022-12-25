using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserServiceGateway.CommonBO;
using UserServiceGateway.DbContexts;
using UserServiceGateway.Models;
using UserServiceGateway.Service.Interface;

namespace UserServiceGateway.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        protected ResponseMessegeBO _response;
        public UsersController(IUserService service, ResponseMessegeBO response)
        {
            _service = service;
            this._response = response;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<Object> GetUsers()
        {
            try
            {
                IEnumerable<UserBO> userBo = await _service.GetAllUsers();
                return _response.Result = userBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<Object> GetUser(int id)
        {
            try
            {
                UserBO userBo = await _service.GetUserById(id);
                return _response.Result = userBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<Object> DeleteUser(int id)
        {
            try
            {
                var result = await _service.DeleteUser(id);
                return _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
