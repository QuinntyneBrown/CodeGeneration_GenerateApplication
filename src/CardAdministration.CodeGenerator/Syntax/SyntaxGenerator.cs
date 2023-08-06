// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace CardAdministration.CodeGenerator.Syntax;

public class SyntaxGenerator : ISyntaxGenerator
{
    private readonly ConcurrentDictionary<Type, Func<dynamic, Task<string>>> _strategies = new ConcurrentDictionary<Type, Func<dynamic, Task<string>>>();
    private readonly ILogger<SyntaxGenerator> _logger;
    private readonly IServiceProvider _serviceProvider;

    public SyntaxGenerator(ILogger<SyntaxGenerator> logger, IServiceProvider serviceProvider)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public async Task<string> GenerateAsync<T>(T model)
    {
        _strategies.TryGetValue(typeof(T), out Func<dynamic, Task<string>>? generateAsync);

        if (generateAsync == null)
        {
            var strategy = _serviceProvider.GetRequiredService<ISyntaxGenerationStrategy<T>>();

            generateAsync = (dynamic model) => strategy.GenerateAsync(model);

            _strategies.TryAdd(typeof(T), generateAsync);
        }

        return await generateAsync(model);
    }
}
