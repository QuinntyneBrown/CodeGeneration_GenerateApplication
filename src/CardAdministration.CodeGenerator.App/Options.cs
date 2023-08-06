// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CommandLine;

namespace CardAdministration.CodeGenerator.App;

public class Options
{
    [Option('p')]
    public required string Path { get; set; }

    [Option('o')]
    public required string OutputDirectory { get; set; } = "..\\..\\..\\..\\CardAdministration.Core\\";

    [Option('t')]
    public required string TemplateDirectory { get; set; } = "..\\..\\..\\..\\CardAdministration.CodeGenerator\\Templates\\";
}
