using eAppointmentServer.Application.Features.Appoinment.GetAllDoctorByDepartment;
using eAppointmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AppointmentsController : ApiController
    {
        public AppointmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("GetAllDoctorByDepartment")]
        public async Task<IActionResult> GetAllDoctorByDepartment(GetAllDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("GetAllByDoctorId")]
        public async Task<IActionResult> GetAllByDoctorId(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

    }
}
