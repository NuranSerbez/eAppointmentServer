using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Roles.RoleSync
{
    public sealed partial record RoleSyncCommand() : IRequest<Result<string>>
    {
    }
}
