// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CardAdministration.CodeGenerator.Artifacts;
using CardAdministration.CodeGenerator.Artifacts.Files;
using CardAdministration.CodeGenerator.Domain;
using CardAdministration.CodeGenerator.Services;
using CardAdministration.CodeGenerator.Syntax;
using CardAdministration.CodeGenerator.Syntax.Structs;
using System.IO.Abstractions;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddCodeGeneratorServices(this IServiceCollection services, Action<CodeGeneratorOptions> configure){
        services.Configure(configure);
        services.AddSingleton<IConceptualModelParser, ConceptualModelParser>();
        services.AddSingleton<IArtifactGenerator , ArtifactGenerator>();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddSingleton<IFileFactory, FileFactory>();
        services.AddSingleton<ITemplateProcessor, RazorTemplateProcessor>();
        services.AddSingleton<ITemplateLocator, TemplateLocator>();

        services.AddSingleton<ISyntaxGenerator, SyntaxGenerator>();


        services.AddSingleton<ISyntaxGenerationStrategy<StructModel>, StructGenerationStrategy>();
        services.AddSingleton<IArtifactGenerationStrategy<SyntaxFileModel<StructModel>>, StructFileGenerationStrategy>();
    }

}
