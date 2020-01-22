using Business.Mediatr.Users.Commands.CreateUser;
using Business.Mediatr.Users.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreRestApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand createUser)
        {
            var result = await _mediator.Send(createUser);
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserQuery loginUser)
        {
            var result = await _mediator.Send(loginUser);
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
