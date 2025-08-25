using App.Api.Events;
using Pr.Cms.BuildingBlock.Domain.Types;

namespace App.Api.Models
{
    public class Car : AggregateRoot
    {

        private Car() { }

        private Car(CarId carId)
        {

            Id = carId;
        }
        public static Car Create()
        {
            var car = new Car(CarId.Create());

            car.AddDomainEvent(new CarCreatedEvent("Test Name"));
            return car;
        }

    }
}
