using Microsoft.OpenApi.Models;

namespace DiscountService.Web;

public static class SchemaProvider
{
  public static OpenApiSchema SchemaForAddRulesRequest => GetSchemaForAddRulesRequest(); 
  private static OpenApiSchema GetSchemaForAddRulesRequest()
  {
    var ruleRecordSchema = new OpenApiSchema()
      {
        Type = "object", 
        Properties =
        {
          ["Id"] = new OpenApiSchema() { Type = "Guid", Nullable = true },
          ["RuleOperator"] = new OpenApiSchema() { Type = "string", Nullable = false},
          ["ComparandAddress"] = new OpenApiSchema() { Type = "string", Nullable = false},
          ["IsComparedToValue"] = new OpenApiSchema() { Type = "bool", Nullable = false, Default = new Microsoft.OpenApi.Any.OpenApiBoolean(false) },
          ["ComparerAddress"] = new OpenApiSchema() { Type = "string", Nullable = true},
          ["Value"] = new OpenApiSchema() { Type = "string", Nullable = true},
        }
      };
      var groupRecordSchema = new OpenApiSchema
      {
        Type = "object",
        Properties =
        {
          ["Id"] = new OpenApiSchema() { Type = "Guid", Nullable = true, Description = "Can be null"},
          ["GroupOperator"] = new OpenApiSchema { Type = "string", Nullable = false },
          ["Rules"] = new OpenApiSchema() { Type = "array", Items = ruleRecordSchema, Nullable = true, },
          ["Children"] = new OpenApiSchema() { Type = "array", Items = new OpenApiSchema()
          {
            Type = "object",
            Properties =
            {
              ["GroupOperator"] = new OpenApiSchema { Type = "string", Nullable = false },
              ["Rules"] = new OpenApiSchema() { Type = "array", Items = ruleRecordSchema, Nullable = true},
            }
          }
          }
        },
        Required = new HashSet<string> { "GroupOperator" }
      };
      
      return new OpenApiSchema
      {
        Type = "object",
        Properties =
        {
          ["DiscountId"] = new OpenApiSchema { Type = "string", Format = "uuid", Nullable = false },
          ["RootGroupId"] = new OpenApiSchema { Type = "string", Format = "uuid", Nullable = true },
          ["RuleGroup"] = groupRecordSchema
        },
        Required = new HashSet<string> { "DiscountId" }
      };
      
  } 
}
