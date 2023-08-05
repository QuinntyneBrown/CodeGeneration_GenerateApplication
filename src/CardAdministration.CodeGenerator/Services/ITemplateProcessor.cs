namespace CardAdministration.CodeGenerator.Services;

public interface ITemplateProcessor
{
    Task<string> ProcessAsync<T>(string template, T model);

}

