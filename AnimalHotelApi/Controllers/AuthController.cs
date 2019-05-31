using AnimalHotelApi.Models;
using Client.Models.User;
using FluentValidation;
using Models.User;
using Models.User.Repository;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AnimalHotelApi.Controllers
{
    [RoutePrefix("api/auth")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IHttpActionResult Auth([FromBody] UserAuthorizationInfo userAuthorizationInfo)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            if (userAuthorizationInfo == null)
            {
                return this.BadRequest("Body must be not null");
            }
            try
            {
                var session = authenticator.Authenticate(userAuthorizationInfo.Login, userAuthorizationInfo.Password);
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