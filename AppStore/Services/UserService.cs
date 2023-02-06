using AppStore.Enums;
using AppStore.Helpers;
using AppStore.Interfaces;
using AppStore.Models;
using AppStore.Models.ViewModels;
using AppStore.Responses;
using System.Security.Claims;

namespace AppStore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IBaseResponse<IEnumerable<User>>> GetUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();

            try
            {
                var users = await _userRepository.Select();
                if (users.Count == 0)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.NotFound;
                    return baseResponse;
                }
                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.Success;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message
                };


            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> Logger(LoggerViewModel model)
        {
            try
            {
                User user = await _userRepository.GetValue(model.Username);
                if (user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "User not exist",
                        StatusCode = StatusCode.NotFound
                    };
                }
                else if(user.Password != PasswordHashHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>
                    {
                        Description = "Wrong password"
                    };
                }

                var result = Authentificate(user);
                return new BaseResponse<ClaimsIdentity>()
                {
                    StatusCode = StatusCode.Success,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                User user = await _userRepository.GetValue(model.Username);
                if (user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "This user already exists"
                    };
                }
                user = new User(
                    username: model.Username,
                    password: PasswordHashHelper.HashPassword(model.Password),
                    email: model.Email
                    );
                await _userRepository.Create(user);
                var result = Authentificate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "User succesfully created",
                    StatusCode = StatusCode.Success
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
         private ClaimsIdentity Authentificate(User user)
         {
             var claims = new List<Claim>
             {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                 new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
             };
             return new ClaimsIdentity(claims, "ApplicationCookie", 
                 ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
         }
        

    }
}
