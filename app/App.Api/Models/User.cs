using App.Api.Events;
using Pr.Cms.BuildingBlock.Domain.Types;

namespace App.Api.Models
{
    public class User : AggregateRoot
    {
        private User() { }

        private User(UserId userId)
        {

            Id = userId;
        }
        public static User Create(string name)
        {
            var user = new User(UserId.Create());
            user.AddDomainEvent(new UserRegisteredEvent(name));

            return user;
        }

    }
}
