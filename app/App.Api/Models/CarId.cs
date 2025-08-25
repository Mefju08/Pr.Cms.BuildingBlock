using Pr.Cms.BuildingBlock.Domain.Types;

namespace App.Api.Models
{
    public record CarId : TypedId
    {
        public CarId(Guid original) : base(original)
        {
        }

        public static CarId Create() => new CarId(Guid.NewGuid());
    }
}
