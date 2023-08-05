using Microsoft.Extensions.Logging;
using RazorEngineCore;

namespace CardAdministration.CodeGenerator.Services;

public class RazorTemplateProcessor: RazorEngine, ITemplateProcessor
{
    private readonly ILogger<RazorTemplateProcessor> _logger;

    public RazorTemplateProcessor(ILogger<RazorTemplateProcessor> logger){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> ProcessAsync<T>(string template, T model)
    {
        _logger.LogInformation("Process template Async");

        var compiledTemplate = await CompileAsync(template);

        return await compiledTemplate.RunAsync(model);
    }

}

