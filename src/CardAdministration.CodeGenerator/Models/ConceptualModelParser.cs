using Microsoft.Extensions.Logging;
using System.IO.Abstractions;
using System.Xml.Linq;

namespace CardAdministration.CodeGenerator.Models;

public class ConceptualModelParser: IConceptualModelParser
{
    private readonly ILogger<ConceptualModelParser> _logger;
    private readonly IFileSystem _fileSystem;

    public ConceptualModelParser(ILogger<ConceptualModelParser> logger, IFileSystem fileSystem){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public async Task<ConceptualModel> ParseAsync(string path)
    {
        _logger.LogInformation("Parse message definitions");

        var model = new ConceptualModel();

        foreach(var file in _fileSystem.Directory.GetFiles(path,"*.xsd",SearchOption.AllDirectories))
        {
            XElement root = XElement.Load(file);

            XNamespace ns = "http://www.w3.org/2001/XMLSchema";

            foreach (var type in from el in root.Elements()
                                       where el.Name == ns + "simpleType"
                                       select el)
            {

                model.SimpleTypes.Add(new SimpleType()
                {
                    Name = type.Attribute("name").Value
                });

            }

            foreach (var type in from el in root.Elements()
                                 where el.Name == ns + "complexType"
                                 select el)
            {

                model.ComplexTypes.Add(new ComplexType(type.Attribute("name")!.Value));

            }
        }



        return model;
    }

}

