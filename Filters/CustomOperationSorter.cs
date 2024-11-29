using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class CustomOperationSorter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var methodOrder = new Dictionary<string, int>
        {
            { "get", 1 },
            { "post", 2 },
            { "put", 3 },
            { "patch", 4 },
            { "delete", 5 }
        };

        foreach (var path in swaggerDoc.Paths.Values)
        {
            // Sort operations by HTTP method using custom order
            var sortedOperations = path.Operations
                .OrderBy(op => methodOrder.ContainsKey(op.Key.ToString().ToLower())
                    ? methodOrder[op.Key.ToString().ToLower()]
                    : int.MaxValue)
                .ToDictionary(op => op.Key, op => op.Value);

            // Clear existing operations and add sorted ones
            path.Operations.Clear();
            foreach (var operation in sortedOperations)
            {
                path.Operations.Add(operation.Key, operation.Value);
            }
        }
    }
}
