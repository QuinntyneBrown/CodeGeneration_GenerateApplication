// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public class Restriction
{
    //string, decimal, date, DateTime, base64Binary
    public string Base { get; set; }


    //string
    public string[] Values = new string[0];

    // decimal
    public int? FractionDigits { get; set; }
    public int? TotalDigits { get; set; }
    public int? MinInclusive { get; set; }

    //base64Binary
    public int MinLength { get; set; }
    public int MaxLength { get; set; }
}

