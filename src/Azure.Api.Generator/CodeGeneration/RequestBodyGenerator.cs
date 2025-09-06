﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.OpenApi;

namespace Azure.Api.Generator.CodeGeneration;

internal sealed class RequestBodyGenerator
{
    private readonly IOpenApiRequestBody? _body;
    private readonly List<RequestBodyContentGenerator> _contentGenerators = [];

    private IOpenApiRequestBody Body =>
        _body ?? throw new NullReferenceException(nameof(_body));

    
    private RequestBodyGenerator()
    {
        
    }
    public RequestBodyGenerator(
        IOpenApiRequestBody body,
        List<RequestBodyContentGenerator> contentGenerators)
    {
        _body = body;
        _contentGenerators = contentGenerators;
    }

    internal static readonly RequestBodyGenerator Empty = new();
    
    internal string GenerateRequestBindingDirective(string propertyName)
    {
        if (_body is null)
        {
            return string.Empty;
        }

        return $"""
                 {propertyName} = RequestContent.Bind(request)
                """;
    }

    public string GenerateRequestProperty(string propertyName)
    {
        if (_body is null)
        {
            return string.Empty;
        }

        return $$"""
                 internal {{(Body.Required ? "required " : "")}}RequestContent{{(Body.Required ? "" : "?")}} {{propertyName}} { get; init; }

                 internal sealed class RequestContent 
                 {
                    {{_contentGenerators.Aggregate(new StringBuilder(), (builder, content) => builder.AppendLine(content.GenerateRequestProperty()))}}
                    
                    internal static RequestContent{{(_body.Required ? "" : "?")}} Bind(HttpRequest request)
                    {
                        var requestContentType = request.ContentType;
                        var requestContentMediaType = requestContentType == null ? null : System.Net.Http.Headers.MediaTypeHeaderValue.Parse(requestContentType);
                 
                        switch (requestContentMediaType?.MediaType?.ToLower()) 
                        {
                            {{_contentGenerators.Aggregate(new StringBuilder(), (builder, content) => builder.AppendLine(
                                $$"""
                                  case "{{content.ContentType.ToLower()}}":
                                      return new RequestContent
                                      {
                                          {{content.GenerateRequestBindingDirective()}}
                                      };
                                  """
                            ))}}
                            {{(_body.Required ? "" :
                                """
                                case "":
                                    return null;
                                """)}}
                                default:
                                    throw new BadHttpRequestException($"Request body does not support content type {requestContentType}");
                        }
                    }
                 }
                 """;
    }
}