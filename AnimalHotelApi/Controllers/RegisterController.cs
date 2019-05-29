using Client.Models.User;
using FluentValidation;
using Models.Converters.Users;
using Models.User;
using Models.User.Repository;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly AbstractValidator<UserRegistrationInfo> validationRules;
        public RegisterController(IUserRepository userRepository, 
            AbstractValidator<UserRegistrationInfo> validationRules)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] UserRegistrationInfo userRegisterInfo)
        {
            var validationResult = validationRules.Validate(userRegisterInfo);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult
                    .Errors
                    .Select(x => x.ErrorMessage);
                return this.BadRequest(string.Join(". ", errorMessages));
            }
            try
            {
                var user = userRepository.Create(UserConverter.Convert(userRegisterInfo));
                return this.Ok(user);
            }
            catch (UserDuplicationException)
            {
                return this.Conflict();
            }
        }
    }
}