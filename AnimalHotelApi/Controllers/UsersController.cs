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

namespace AnimalHotelApi.Controllers
{
    using Model = global::Models.User;

    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthentificator authenticator;
        private readonly AbstractValidator<UserPatchInfo> validationRules;

        public UsersController(IUserRepository userRepository, IAuthentificator authenticator,
            AbstractValidator<UserPatchInfo> validationRules)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.authenticator = authenticator ?? throw new ArgumentNullException(nameof(authenticator));
            this.validationRules = validationRules ?? throw new ArgumentNullException(nameof(validationRules));
        }

        [HttpPatch]
        [Route("{userId}")]
        public IHttpActionResult Patch(string userId, [FromBody]UserPatchInfo patchInfo)
        {
            var validationResult = validationRules.Validate(patchInfo);
            if (!validationResult.IsValid)
            {
                var errorMessages = validationResult
                    .Errors
                    .Select(x => x.ErrorMessage);
                return this.BadRequest(string.Join(". ", errorMessages));
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