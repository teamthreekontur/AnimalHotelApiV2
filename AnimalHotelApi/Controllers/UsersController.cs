using AnimalHotelApi.Models;
using Client.Models.User;
using FluentValidation;
using Models.Converters.Users;
using Models.User.Repository;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AnimalHotelApi.Controllers
{
    using Model = global::Models.User;

    [RoutePrefix("api/users")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthentificator authenticator;

        public UsersController(IUserRepository userRepository, IAuthentificator authenticator)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
        }

        [HttpPatch]
        [Route("{userId}")]
        public IHttpActionResult Patch(string userId, [FromBody]UserPatchInfo patchInfo)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            if (patchInfo == null)
            {
                return this.BadRequest("Body must be not null");
            }

            if (!Guid.TryParse(userId, out var userIdGuid))
            {
                return BadRequest();
            }

            string sessionId = "";
            CookieHeaderValue cookie = Request.Headers.GetCookies("SessionId").FirstOrDefault();
            if (cookie != null)
            {
                sessionId = cookie["SessionId"].Value;
            }

            if (!authenticator.TryGetSession(sessionId, out var sessionState))
            {
                return Unauthorized();
            }

            var userPatchInfo = UserPatchInfoConverter.Convert(userIdGuid, patchInfo);
            Model.User modelUser = null;

            try
            {
                modelUser = userRepository.Patch(userPatchInfo);
            }
            catch (Model.UserNotFoundException)
            {
                return NotFound();
            }

            return Ok(UserConverter.Convert(modelUser));
        }
    }
}