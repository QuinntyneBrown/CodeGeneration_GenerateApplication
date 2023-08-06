// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public class DomainModel
{

    public DomainModel()
    {
        ComplexTypes = new();
        SimpleTypes = new();
    }
    public List<ComplexType> ComplexTypes { get; set; }
    public List<SimpleType> SimpleTypes { get; set; }
}

