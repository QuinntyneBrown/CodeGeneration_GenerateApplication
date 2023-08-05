using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CardAdministration.CodeGenerator.Services;

public class CommandService: ICommandService
{
    private readonly ILogger<CommandService> _logger;

    public CommandService(ILogger<CommandService> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task DoWorkAsync()
    {
        _logger.LogInformation("DoWorkAsync");
    }

}

