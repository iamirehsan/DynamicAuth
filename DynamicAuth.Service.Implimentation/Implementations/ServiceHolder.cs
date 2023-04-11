using DynamicAuth.Domain.Entites;
using DynamicAuth.Service;
using DynamicAuth.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DynamicAuth.Service.Implimentation.Implementations;

public class ServiceHolder : IServiceHolder
{
    private UserFunctionsService _userFunctionsService;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public ServiceHolder(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public IUserFunctionsService UserFunctionsService => _userFunctionsService=_userFunctionsService?? new UserFunctionsService(_userManager,_configuration) ;
}
