using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using TS.Result;
using Microsoft.EntityFrameworkCore;

namespace eAppointmentServer.Application.Features.Doctors.GetAllDoctor;

internal sealed class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorsQuery, Result<List<Doctor>>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetAllDoctorQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = await _doctorRepository
            .GetAll()
            .OrderBy(p => p.Department)
            .ThenBy(p => p.FirstName)
            .ToListAsync(cancellationToken);

        return doctors;
    }
}
