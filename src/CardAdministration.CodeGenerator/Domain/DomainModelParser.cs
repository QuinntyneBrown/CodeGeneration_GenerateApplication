// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;
using System.IO.Abstractions;
using System.Xml.Linq;

namespace CardAdministration.CodeGenerator.Domain;

public class ConceptualModelParser : IConceptualModelParser
{
    private readonly ILogger<ConceptualModelParser> _logger;
    private readonly IFileSystem _fileSystem;
    private DomainModel _conceptualModel;
    public ConceptualModelParser(ILogger<ConceptualModelParser> logger, IFileSystem fileSystem)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
    }

    public async Task<DomainModel> ParseAsync(string path)
    {
        _logger.LogInformation("Parse message definitions");

        if (_conceptualModel == null)
        {
            var model = new DomainModel();

            foreach (var file in _fileSystem.Directory.GetFiles(path, "*.xsd", SearchOption.AllDirectories))
            {
                XElement root = XElement.Load(file);

                XNamespace ns = "http://www.w3.org/2001/XMLSchema";

                foreach (var typeName in new string[2] { "simpleType", "complexType" })
                {
                    foreach (var type in from el in root.Elements()
                                         where el.Name == ns + typeName
                                         select el)
                    {
                        switch (typeName)
                        {
                            case "simpleType":
                                model.SimpleTypes.Add(new SimpleType(type.Attribute("name")!.Value));
                                break;

                            case "complexType":
                                var complexType = new ComplexType(type.Attribute("name")!.Value);

                                foreach (var sequence in from seq in type.Descendants()
                                                         where seq.Name == ns + "sequence"
                                                         select seq)
                                {
                                    foreach (var sequenceElement in from el in sequence.Descendants()
                                                                    where el.Name == ns + "element"
                                                                    select el)
                                    {
                                        complexType.Sequence.Add(new Sequence()
                                        {
                                            Name = sequenceElement.Attribute("name")!.Value,
                                            Type = sequenceElement.Attribute("type")!.Value
                                        });
                                    }
                                }

                                model.ComplexTypes.Add(complexType);

                                break;
                        }
                    }
                }
            }

            _conceptualModel = model;
        }



        return _conceptualModel;
    }

}


