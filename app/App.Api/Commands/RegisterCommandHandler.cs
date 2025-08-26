using App.Api.DAL;
using App.Api.Models;
using Pr.Cms.BuildingBlock.Domain.Repositories;

namespace App.Api.Commands
{
    public class RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        ICarRepository carRepository)
    {
        public async Task<Guid> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            Console.WriteLine("Zarejestrowano");
            var user = User.Create(command.FirstName);
            await carRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Id.Value;

        }
    }
}
