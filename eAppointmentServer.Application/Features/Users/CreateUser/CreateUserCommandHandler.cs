using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.CreateUser
{
    internal sealed class CreateUserCommandHandler(
     UserManager<AppUser> userManager,
     IUserRoleRepository userRoleRepository,
     IUnitOfWork unitOfWork,
     IMapper mapper) : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await userManager.Users.AnyAsync(p => p.Email == request.Email))
            {
                return Result<string>.Failure(404, ["Email already exists"]);
            }

            if (await userManager.Users.AnyAsync(p => p.UserName == request.UserName))
            {
                return Result<string>.Failure(404, ["User name already exists"]);
            }

            AppUser user = mapper.Map<AppUser>(request);
            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return Result<string>.Failure(400, result.Errors.Select(error => error.Description).ToList());
            }

            if (request.RoleIds.Any())
            {
                List<AppUserRole> userRoles = new();
                foreach (var roleId in request.RoleIds)
                {
                    AppUserRole userRole = new()
                    {
                        RoleId = roleId,
                        UserId = user.Id
                    };
                    userRoles.Add(userRole);
                }

                await userRoleRepository.AddRangeAsync(userRoles, cancellationToken);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return "User create is successful";
        }
    }
}
