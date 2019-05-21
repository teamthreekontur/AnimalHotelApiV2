using AnimalHotelApi.Models;
using Client.Models.User;
using Models.User;
using Models.User.Repository;
using System;
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
            this.authenticator = authenticator;
        }

        [HttpPost]
        public IHttpActionResult Auth([FromBody] UserRegistrationInfo userRegisterInfo)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
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