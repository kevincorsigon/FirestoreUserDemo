using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirestoreUserDemo.Models;
using FirestoreUserDemo.Services;

namespace FirestoreUserDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }               

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<User> Get([FromRoute] string id)
        {
            return await _userService.GetById(id);
        }

        [HttpPost]
        public async Task<User> Post([FromBody] User user)
        {
            return await _userService.Create(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<User> Put([FromRoute] string id, [FromBody] User user)
        {
            user.Id = id;
            return await _userService.Update(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] string id)
        {
            await _userService.Delete(id);
        }        
    }
}
