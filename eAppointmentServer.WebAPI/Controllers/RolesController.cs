using Azure.Core;
using eAppointmentServer.Application.Features.Roles.RoleSync;
using eAppointmentServer.WebAPI.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace eAppointmentServer.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class RolesController : ApiController
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Sync")]
        public async Task<IActionResult> Sync(RoleSyncCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
