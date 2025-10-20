using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId
{
    public sealed record GetAllAppointmentsByDoctorIdQueryResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Title,
    Patient Patient);
}
