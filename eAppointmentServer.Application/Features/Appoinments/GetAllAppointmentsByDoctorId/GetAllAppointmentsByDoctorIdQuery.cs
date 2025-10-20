using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId
{
    public sealed partial record GetAllAppointmentsByDoctorIdQuery(Guid DoctorId) : IRequest<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>
    {
    }
}
