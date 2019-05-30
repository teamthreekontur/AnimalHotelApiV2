namespace AnimalHotelApi.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class SessionState
    {
        public SessionState(Guid sessionId, Guid userId, DateTime expired)
        {
            if (sessionId == null)
            {
                throw new ArgumentNullException(nameof(sessionId));
            }

            this.SessionId = sessionId;
            this.UserId = userId;
            this.Expired = expired;
        }

        [BsonId]
        public Guid SessionId { get; }

        public Guid UserId { get; }

        public DateTime Expired { get; }
    }
}
