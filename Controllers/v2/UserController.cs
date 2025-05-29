using Asp.Versioning;
using DTO.Shift;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.v2;
using System.IdentityModel.Tokens.Jwt;
using WASA_CoreLib.Entity;

namespace WASA_API.Controllers.v2
{
    [ApiVersion("2.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        private string GetToken()
        {
            var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            expires: null,
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> RegUser(RegUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.RegUser(request);
                if (data != null)
                {
                    data.Token = GetToken();
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                }
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> AuthUser(AuthUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.AuthUser(request);
                if (data != null)
                {
                    data.Token = GetToken();
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                }
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpPost]
        public async Task<ServerResponseEntity> GrantAccessUser(GrantAccessUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.GrantAccessUser(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpPut]
        public async Task<ServerResponseEntity> UpdateUser(int id, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.UpdateUser(id, request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }


        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpPost]
        public async Task<ServerResponseEntity> GetUserDataById(ShowByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.GetUserDataById(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("2.0")]
        [Authorize]
        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            await _userService.Delete(id);
        }
    }
}
