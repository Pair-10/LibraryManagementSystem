using NArchitecture.Core.Security.Attributes;

namespace Application.Features.MaterialLocations.Constants;

[OperationClaimConstants]
public static class MaterialLocationsOperationClaims
{
    private const string _section = "MaterialLocations";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}