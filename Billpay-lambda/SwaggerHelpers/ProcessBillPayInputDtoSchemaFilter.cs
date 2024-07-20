using Billpay_lambda.InputDtos;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Billpay_lambda.SwaggerHelpers;

public class ProcessBillPayInputDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(ProcessBillPayInputDto))
        {
            schema.Example = new OpenApiObject
            {
                ["transactionid"] = new OpenApiString("00000000-0000-0000-0000-000000000000"),
                ["istransactionsummary"] = new OpenApiBoolean(false),
                ["screenData"] = new OpenApiObject
                {
                    ["dataelements"] = new OpenApiArray
                {
                    new OpenApiObject
                    {
                        ["label"] = new OpenApiString(string.Empty),
                        ["value"] = new OpenApiString(string.Empty)
                    }
                },
                    ["screentype"] = new OpenApiString(string.Empty)
                }
            };
        }
    }
}
