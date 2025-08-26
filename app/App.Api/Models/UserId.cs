using Pr.Cms.BuildingBlock.Domain.Types;

namespace App.Api.Models
{
    public record UserId : TypedId
    {
        public UserId(Guid original) : base(original)
        {
        }

        public static UserId Create() => new UserId(Guid.NewGuid());
    }
}
