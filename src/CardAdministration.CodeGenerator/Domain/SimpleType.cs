// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public class SimpleType
{
    public SimpleType(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

    //string, date, datetime
    public Restriction Restriction { get; set; }
}

