using System;

namespace DekamikCrud.Entities
{
    public abstract class BaseTimestampedEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
