using Asp.Versioning;
using DTO.Shift;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Services.v1;
using WASA_CoreLib.Entity;

namespace WASA_API.Controllers.v1
{
    [ApiVersion("1.0", Deprecated = false)]
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> RegUser(RegUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.RegUser(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<ServerResponseEntity> AuthUser(AuthUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var data = await _userService.AuthUser(request);
                if (data != null)
                    return new() { StatusCode = System.Net.HttpStatusCode.OK, Data = data, Message = "Обработано успешно" };
                return new() { StatusCode = System.Net.HttpStatusCode.NoContent, Message = "Произошла ошибка при обработке запроса сервером" };
            }
            return new() { StatusCode = System.Net.HttpStatusCode.BadRequest, Message = "Были отправлены некорректные данные" };
        }

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
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


        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
        [HttpDelete]
        public async Task DeleteUser(int id)
        {
            await _userService.Delete(id);
        }
    }
}
