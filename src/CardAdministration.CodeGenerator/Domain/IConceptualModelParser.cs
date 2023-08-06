// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public interface IConceptualModelParser
{
    Task<DomainModel> ParseAsync(string path);
}


