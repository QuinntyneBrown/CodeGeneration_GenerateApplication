// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CardAdministration.CodeGenerator.App;
using CardAdministration.CodeGenerator.Artifacts;
using CardAdministration.CodeGenerator.Artifacts.Files;
using CardAdministration.CodeGenerator.Domain;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await RunAsync();

async Task RunAsync()
{
    var parsedResult = _createParser().ParseArguments<Options>(args);

    var host = Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
        services.AddLogging();
        services.AddCodeGeneratorServices(x =>
        {
            x.TemplatesDirectory = parsedResult.Value.TemplateDirectory;
            x.OutputDirectory = parsedResult.Value.OutputDirectory;
        });

        services.AddSingleton(services =>
        {
            var parser = services.GetRequiredService<IDomainModelParser>();

            return parser.ParseAsync(parsedResult.Value.Path).ConfigureAwait(false).GetAwaiter().GetResult();
        });

    }).Build();

    var model = host.Services.GetRequiredService<DomainModel>();

    var generator = host.Services.GetRequiredService<IArtifactGenerator>();

    var fileFactory = host.Services.GetRequiredService<IFileFactory>();

    foreach (var type in model.ComplexTypes)
    {
        var fileModel = await fileFactory.CreateComplexType(type, parsedResult.Value.OutputDirectory);

        await generator.GenerateAsync(fileModel);
    }
}

Parser _createParser() => new Parser(with =>
{
    with.CaseSensitive = false;
    with.HelpWriter = Console.Out;
    with.IgnoreUnknownArguments = true;
});
