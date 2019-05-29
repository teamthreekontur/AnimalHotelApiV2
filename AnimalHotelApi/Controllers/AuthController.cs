using AnimalHotelApi.Models;
using Client.Models.User;
using FluentValidation;
using Models.User;
using Models.User.Repository;
using System;
using System.Linq;
using System.Web.Http;


namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthentificator authenticator;
        private readonly AbstractValidator<UserRegistrationInfo> validationRules;

        public AuthController(IUserRepository repository, IAuthentificator authenticator,
            AbstractValidator<UserRegistrationInfo> validationRules)
        {
            this.userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
            this.validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
        }

        [HttpPost]
        public IHttpActionResult Auth([FromBody] UserRegistrationInfo userRegisterInfo)
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
                var session = authenticator.Authenticate(userRegisterInfo.Login, userRegisterInfo.Password);
                return this.Ok(session);
            }
            catch (UserNotFoundException)
            {
                return this.NotFound();
            }
            catch (Exception)
            {
                return this.Conflict();
            }
        }
    }
}