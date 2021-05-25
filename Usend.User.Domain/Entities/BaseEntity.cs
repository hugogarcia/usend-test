using System;

namespace Usend.UserApi.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
