using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctorById
{
    internal sealed class DeleteDoctorByIdCommandHandler(
        IDoctorRepository doctorRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteDoctorByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteDoctorByIdCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await doctorRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

            if (doctor is null)
            {
                return Result<string>.Failure(404, ["Doctor not found."]);
            }

            doctorRepository.Delete(doctor);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Succeed("Doctor deletion is successful.");
        }
    }
}
