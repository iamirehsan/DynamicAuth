using DynamicAuth.Domain.Entites;
using DynamicAuth.Repository;
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
    private readonly IRedisService _redisService;
    private readonly IUnitOfWork _unittOfWork;

    public ServiceHolder(UserManager<User> userManager, IConfiguration configuration, IRedisService redisService, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _configuration = configuration;
        _redisService = redisService;
        _unittOfWork = unitOfWork;
    }

    public IUserFunctionsService UserFunctionsService => _userFunctionsService=_userFunctionsService?? new UserFunctionsService(_userManager,_configuration,_unittOfWork,_redisService) ;
}
