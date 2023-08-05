namespace CardAdministration.CodeGenerator.Models;

public interface IConceptualModelParser
{
    Task<ConceptualModel> ParseAsync(string path);
}

