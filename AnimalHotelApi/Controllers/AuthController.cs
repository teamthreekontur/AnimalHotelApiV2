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

        public AuthController(IUserRepository repository, IAuthentificator authenticator)
        {
            this.userRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }

        [HttpPost]
        public IHttpActionResult Auth([FromBody] UserRegistrationInfo userRegisterInfo)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
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