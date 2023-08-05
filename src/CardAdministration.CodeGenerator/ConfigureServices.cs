using CardAdministration.CodeGenerator.Artifacts;
using CardAdministration.CodeGenerator.Artifacts.Files;
using CardAdministration.CodeGenerator.Models;
using CardAdministration.CodeGenerator.Services;
using System.IO.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCodeGeneratorServices(this IServiceCollection services, Action<CodeGeneratorOptions> configure){

        services.Configure(configure);
        services.AddSingleton<IConceptualModelParser, ConceptualModelParser>();
        services.AddSingleton<IArtifactGenerator , ArtifactGenerator>();
        services.AddSingleton<IArtifactGenerationStrategy<ClassModel>, ClassGenerationStrategy>();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddSingleton<IFileFactory, FileFactory>();
        services.AddSingleton<ITemplateProcessor, RazorTemplateProcessor>();
        services.AddSingleton<ITemplateLocator, TemplateLocator>();
    }

}

