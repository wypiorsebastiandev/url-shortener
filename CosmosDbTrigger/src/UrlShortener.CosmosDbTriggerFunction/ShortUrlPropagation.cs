﻿using System;
using System.Collections.Generic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace UrlShortener.CosmosDbTriggerFunction;

public class ShortUrlPropagation
{
    private readonly ILogger<ShortUrlPropagation> _logger;

    public ShortUrlPropagation(ILogger<ShortUrlPropagation> logger)
    {
        _logger = logger;
    }

    [Function("ShortUrlPropagation")]
    public void Run([CosmosDBTrigger(
            databaseName: "urls",
            containerName: "items",
            Connection = "",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)]
        IReadOnlyList<MyDocument> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);
            _logger.LogInformation("First document Id: " + input[0].Id);
        }

        
    }
}

public class MyDocument
{
    public string Id { get; set; }

    public string Text { get; set; }

    public int Number { get; set; }

    public bool Boolean { get; set; }
}