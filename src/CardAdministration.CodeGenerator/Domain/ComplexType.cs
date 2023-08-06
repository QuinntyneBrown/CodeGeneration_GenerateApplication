// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CardAdministration.CodeGenerator.Domain;

public class ComplexType {

	public ComplexType(string name)
	{
		Name = name;
        Sequence = new List<Sequence>();
	}
    public string Name { get; set; }
    public List<Sequence> Sequence { get; set; }
}
