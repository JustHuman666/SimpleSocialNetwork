﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetworkAPI.Models;
using NetworkBLL.EntetiesDto;
using NetworkBLL.Interfaces;

namespace NetworkAPI.Controllers
{
    /// <summary>
    /// Controller for authentification processes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IAuthentificationService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor for creating of controller with given services and mapper profile
        /// </summary>
        /// <param name="mapper">Auto mapper profile for models and dtos</param>
        /// <param name="authService">Authentification service</param>
        /// <param name="userService">User service</param>
        public AuthentificationController(IAuthentificationService authService, IUserService userService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// The registration of new user
        /// </summary>
        /// <param name="registerModel">Model of registered user</param>
        /// <returns>Instance of object result of creating user</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUSer([FromBody] RegisterModel registerModel)
        {
            return new ObjectResult(await _authService.RegisterNewUserAsync(_mapper.Map<UserDto>(registerModel), registerModel.Password))
            { StatusCode = StatusCodes.Status201Created };
        }

        /// <summary>
        /// To log user in network
        /// </summary>
        /// <param name="loginModel">Instance of data for logging in</param>
        /// <returns>Result status code</returns>
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody]LoginModel loginModel)
        {
            var user = await _userService.GetUserByEmailAsync(loginModel.Email);
            await _userService.CheckUserPasswordAsync(user.Id, loginModel.Password);
            return Ok(await _authService.LoginUserAsync(user));
        }
    }
}