using Codeflix.Catalog.Infra.Messaging.Extensions;
using System.Text.Json;

namespace Codeflix.Catalog.Infra.Messaging.JsonPolicies;

public class JsonSnakeCasePolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
        => name.ToSnakeCase();
}
