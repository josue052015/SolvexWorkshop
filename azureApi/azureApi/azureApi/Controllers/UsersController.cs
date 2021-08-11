using azureApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace azureApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly UserService _service;

        public UsersController(IAuthenticationProvider authenticationProvider, UserService service)
        {
            _authenticationProvider = authenticationProvider;
            this._service = service;
        }
        [HttpGet]
        public async Task<List<User>> GetUser()
        {
            //var sc = new GraphServiceClient(_authenticationProvider);
            //var users = await sc.Users.Request().GetAsync();
            //return users.ToList();
            var result = await _service.GetUsers();
            return (List<User>)result;


        }
    }
}
