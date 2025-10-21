using eAppointmentServer.Application.Features.Appoinments.CreateAppointment;
using eAppointmentServer.Application.Features.Appoinments.DeleteAppointmentById;
using eAppointmentServer.Application.Features.Appoinments.GetAllAppointmentsByDoctorId;
using eAppointmentServer.Application.Features.Appoinments.GetAllDoctorByDepartment;
using eAppointmentServer.Application.Features.Appoinments.GetPatientByIdentityNumber;
using eAppointmentServer.Application.Features.Appoinments.UpdateAppointment;
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
        [HttpPost("GetPatientByIdentityNumber")]
        public async Task<IActionResult> GetPatientByIdentityNumber(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("DeleteById")]
        public async Task<IActionResult> DeleteById(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        
    }
}
