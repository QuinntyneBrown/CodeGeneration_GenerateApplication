namespace CardAdministration.CodeGenerator.Services;

public interface ITemplateLocator
{
    Task<string> Get(string name);

}

