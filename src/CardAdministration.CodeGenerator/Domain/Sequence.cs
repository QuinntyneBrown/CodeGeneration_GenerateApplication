// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public class Sequence
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string MaxOccurs { get; set; }
    public string MinOccurs { get; set; }
}
