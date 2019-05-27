namespace AnimalHotelApi.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class SessionState
    {
        public SessionState(Guid sessionId, Guid userId)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException(nameof(sessionId));
            }

            this.SessionId = sessionId;
            this.UserId = userId;
        }

        [BsonId]
        public Guid SessionId { get; }

        public Guid UserId { get; }
    }
}
