using System;

namespace CardAdministration.CodeGenerator.Models;

public class ConceptualModel {

    public ConceptualModel()
    {
        ComplexTypes = new();
        SimpleTypes = new();    
    }
    public List<ComplexType> ComplexTypes { get; set; }
    public List<SimpleType> SimpleTypes { get; set; }
}
