// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.Text;

namespace CardAdministration.CodeGenerator.Syntax.Structs;

public class StructGenerationStrategy : ISyntaxGenerationStrategy<StructModel>
{
    private readonly ILogger<StructGenerationStrategy> _logger;

    public StructGenerationStrategy(ILogger<StructGenerationStrategy> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> GenerateAsync(StructModel model)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"partial record struct {model.Name}");

        sb.AppendLine("{");

        foreach (var property in model.Properties)
        {
            sb.AppendLine(($"public string {property.Name}" + " { get; set; }").Indent(1));
        }

        sb.AppendLine("}");

        return sb.ToString();
    }
}

