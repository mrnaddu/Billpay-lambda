using Billpay_lambda.InputDtos;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Billpay_lambda.SwaggerHelpers;

public class UserPreferenceInputDtoSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(UserPreferenceInputDto))
        {
            schema.Example = new OpenApiObject
            {
                ["userid"] = new OpenApiString(Guid.Empty.ToString()),
                ["tenantIds"] = new OpenApiArray
                {
                    new OpenApiString(Guid.Empty.ToString())
                }
            };
        }
    }
}
